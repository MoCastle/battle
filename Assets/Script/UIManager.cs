using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;
using FrameWorkModule;

namespace GameManager
{
    public class UIManager : BaseSingleton<UIManager>
    {
        UIManagertest uiMgr;
        public UIManager()
        {
            //uiMgr = GameEntry.Singleton.GetManager<GameUIManager>();
        }
        public void ShowUI(string UIName)
        {
            uiMgr.ShowUI(UIName);
        }
    }
}

