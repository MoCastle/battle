using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkModule.UI
{
    public interface IUIModule
    {
        void OpenUIForm(string uiName);
        void AddGroup(IUIGroup group);
    }
}

