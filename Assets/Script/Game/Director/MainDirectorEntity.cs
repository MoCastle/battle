using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule.Scene;
namespace GameScene
{
    public abstract class BaseMainDirectorEntity : MonoBehaviour, IMainSceneDirector
    {
        public abstract bool leaved { get; }
        public abstract void LeaveScene();
    }
}

