using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameWorkModule
{
    public abstract class BaseFrameWorkModule
    {
        private bool m_Removed;
        public bool Removed
        {
            get
            {
                return m_Removed;
            }
        }
        public BaseFrameWorkModule()
        { }
        public abstract void Update();
        public abstract void Start();
    }


}
