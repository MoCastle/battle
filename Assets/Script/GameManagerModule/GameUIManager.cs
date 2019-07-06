using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule;
using FrameWorkModule.UI;
using UI;

namespace GameManager
{
    public class GameUIManager : BaseGameManager<GameUIManager>, IGameManager
    {
        IUIModule m_UIModule;
        public override void Init()
        {
            m_UIModule = GameEntry.Singleton.GetModule<UIModule>();
        }
        public override void Start()
        {
            base.Start();
            RectTransform UI = GameEntry.Singleton.driver.UI;
            foreach(Transform group in UI)
            {
                IUIGroup groupComp = group.GetComponent<IUIGroup>();
                m_UIModule.AddGroup(groupComp);
            }
        }

        public void OpenForm(UIType formType)
        {
            m_UIModule.OpenUIForm(formType.ToString());
        }
    }
}

