using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject Target;

    bool isStart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isStart)
        {
            isStart = true;
            string[] vs = { "Player|你好你好啊手动阀手动阀手动阀啊十分大方","Test|闹事的佛阿苏告诉广大" };
            UIMgr.Ins.OpenPanel<UITextPanel>().StartTalk(vs,()=>isStart = false);   
        }
    }

}
