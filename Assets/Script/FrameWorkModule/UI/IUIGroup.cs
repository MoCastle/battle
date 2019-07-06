using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkModule.UI
{
    public interface IUIGroup
    {
        int layer
        {
            get;
        }
        string name
        {
            get;
        }
        void AddUI(BaseUILogic logic);
        void RemoveUI(BaseUILogic logic);
        IUIForm GetUIForm(string name);
    }
}

