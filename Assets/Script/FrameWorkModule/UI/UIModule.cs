using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule;

namespace FrameWorkModule.UI
{
    public class UIModule : BaseFrameWorkModule,IUIModule
    {
        #region 内部属性
        //当前已打开的UI
        Dictionary<string,IUIGroup> m_Groups;
        #endregion

        public UIModule():base()
        {
            m_Groups = new Dictionary<string, IUIGroup>();
        }

        public void OpenUIForm(string uiName)
        {
            IUIForm uiForm = GetUIForm(uiName);

        }

        public IUIForm GetUIForm(string uiName)
        {
            IUIForm uiForm = null;
            foreach ( KeyValuePair<string,IUIGroup> pairs in m_Groups )
            {
                uiForm = pairs.Value.GetUIForm(uiName);
                if(uiForm!= null)
                {
                    break;
                }
            }
            return uiForm;
        }

        public override void Start()
        {
        }

        public override void Update()
        {
        }
        #region 分组
        public void AddGroup(IUIGroup group)
        {
            m_Groups.Add(group.name,group);
        }
        #endregion
    }
}

