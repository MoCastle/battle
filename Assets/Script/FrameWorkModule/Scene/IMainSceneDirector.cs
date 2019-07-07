using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkModule.Scene
{
    public interface IMainSceneDirector
    {
        bool leaved { get; }
        void LeaveScene();
    }
}

