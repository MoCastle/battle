using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using GameScene;

public class FriendlyNPC : NPCObj
{
    public KeyInput input;
    public DialogObj dialogArea;
    public UIMgr uIMgr;
    public GameObject dialogTips;
    private bool dialoging;
    float time;

    protected override void Init()
    {
        m_IDLayer = LayerMask.GetMask("Default");//1 << LayerMask.NameToLayer("Enemy");
        m_ActionCtrler = new ActionCtrler(this, m_CharacterAnim.Animator);//, info.ActorActionList);
        dialogArea.enterTrigerAction = TriggerDialog;
        dialogArea.leaveTrigerAction = HideDialog;
        dialogTips.active = false;
    }

    void TriggerDialog(PlayerObj playerObj)
    {
        
        dialogTips.active = true;
        playerObj.friendlyNPCList.Add(this);
        if(playerObj== null)
        {
            Debug.Log("a");
        }
    }
    void HideDialog(PlayerObj playerObj)
    {
        dialogTips.active = false;
        playerObj.friendlyNPCList.Remove(this);
    }
    
    public void OnDialog()
    {
        if(time - Time.time>0)
        {
            return;
        }
        if(dialoging || DialogInfos.Length <1|| DialogInfos[0].linesInfo.Length <1)
        {
            return;
        }
        dialoging = true;

        DialogLine[] diArr = DialogInfos[0].linesInfo;
        string[] strList = DialogInfos[0].GetDialogInfo();
        InputManager.Singleton.PauseInput();
        uIMgr.OpenPanel<UITextPanel>().StartTalk(strList, ()=> { OnHideDialog();
            if(DialogInfos[0].onDialogEnd!=null) DialogInfos[0].onDialogEnd(); } , OnForceCancelDialog);
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
