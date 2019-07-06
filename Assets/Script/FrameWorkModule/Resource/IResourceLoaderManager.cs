using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule.Resource;
namespace FrameWorkModule
{
    public interface IResourceManager
    {
        void LoadScene(string name, LoadSceneCallbacks loadSceneCallbacks);
    }
}

