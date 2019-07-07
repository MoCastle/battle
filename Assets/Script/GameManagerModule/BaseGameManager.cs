using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;
using FrameWorkModule;

namespace GameManager
{
    public abstract class BaseGameManager<GameManagerType> : BaseSingleton<GameManagerType> where GameManagerType : BaseSingleton<GameManagerType>
    {
        protected bool m_Starting;
        protected bool m_Started;
        public bool started
        {
            get
            {
                return m_Started;
            }
        }
        public bool starting
        {
            get
            {
                return m_Starting;
            }
        }
        public virtual int priority
        {
            get
            {
                return 1;
            }
        }
        public abstract void Init();
        public virtual void Start()
        {
            m_Starting = true;
        }
        public virtual void OnStarted()
        {
            m_Starting = false;
            m_Started = true;
        }
    }
}


