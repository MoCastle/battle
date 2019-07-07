using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule.UI;
using FrameWorkModule;

namespace UI
{
    public class UIGroup : MonoBehaviour, IUIGroup
    {
        #region 字段
        Canvas m_Canvas;
        Dictionary<string, IUIForm> m_UIForms;
        #endregion
        #region 属性
        public int layer
        {
            get
            {
                return m_Canvas.renderOrder;
            }
        }
        public string name
        {
            get
            {
                return gameObject.name;
            }
        }
        #endregion
        public void Awake()
        {
            m_Canvas = GetComponent<Canvas>();
            m_UIForms = new Dictionary<string, IUIForm>();
        }

        public void AddUI(BaseUILogic logic)
        {
        }

        public void RemoveUI(BaseUILogic logic)
        {
        }

        public IUIForm GetUIForm(string name)
        {
            IUIForm target = null;
            m_UIForms.TryGetValue(name, out target);
            return target;
        }
    }
}

