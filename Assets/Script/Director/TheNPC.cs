using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using GameScene;
public class TheNPC : MonoBehaviour {
    [SerializeField]
    [Header("对话信息")]
    public ActorDialogInfo[] DialogInfos;
    public KeyInput input;
    public DialogObj dialogArea;
    public UIMgr uIMgr;
    public GameObject dialogTips;
    private bool dialoging;
    float time;
    private void Start()
    {
        //dialogArea.enterTrigerAction += EnterTriggerAction;
        //dialogArea.leaveTrigerAction += LeaveTriggerAction;
    }
    public void EnterTriggerAction(PlayerObj player)
    {
        dialogTips.active = true;
    }
    public void LeaveTriggerAction(PlayerObj player)
    {
        dialogTips.active = false;
    }
    public void OnDialog(int id = 0)
    {
        if (time - Time.time > 0)
        {
            return;
        }
        if (dialoging || DialogInfos.Length < 1 || DialogInfos[id].linesInfo.Length < 1)
        {
            return;
        }
        dialoging = true;

        DialogLine[] diArr = DialogInfos[id].linesInfo;
        string[] strList = DialogInfos[id].GetDialogInfo();
        InputManager.Singleton.PauseInput();
        uIMgr.OpenPanel<UITextPanel>().StartTalk(strList, () => {
            OnHideDialog();
            if (DialogInfos[id].onDialogEnd != null) DialogInfos[id].onDialogEnd();
        }, 
        OnForceCancelDialog);
        InputManager.Singleton.PauseInput();
        dialogTips.active = false;
    }

    public void OnForceCancelDialog()
    {
        if (DialogInfos.Length < 2 || DialogInfos[1].linesInfo.Length < 1)
        {
            return;
        }
        dialoging = true;

        DialogLine[] diArr = DialogInfos[1].linesInfo;
        string[] strList = DialogInfos[1].GetDialogInfo();
        InputManager.Singleton.PauseInput();
        uIMgr.OpenPanel<UITextPanel>().StartTalk(strList, OnHideDialog, OnForceCancelDialog);
        dialogTips.active = true;
    }

    public void OnHideDialog()
    {
        time = Time.time + 0.4f;
        InputManager.Singleton.ContinueInput();
        dialoging = false;
    }

}
