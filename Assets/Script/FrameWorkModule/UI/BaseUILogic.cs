using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkModule
{
    public abstract class BaseUILogic : MonoBehaviour
    {
        [Header("分组名")]
        public string groupName = "Default";
        public abstract void Open();
        public abstract void Close();
    }
}

