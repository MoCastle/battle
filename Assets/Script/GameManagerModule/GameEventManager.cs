using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule;
using FrameWorkModule.Event;

namespace GameManager
{
    public class GameEventManager : BaseGameManager<GameEventManager>, IGameManager
    {
        #region 变量
        IEventModule m_EventModule;
        #endregion
        #region 接口
        #endregion
        #region 流程
        public override void Init()
        {
            m_EventModule = GameEntry.Singleton.GetModule<EventModule>();
        }

        public override void Start()
        {
            base.Start();
            OnStarted();
        }
        #endregion
        #region 事件
        public void Regist(int id, EventHandler handler)
        {
            m_EventModule.Regist(id, handler);
        }

        public void Fire(int id)
        {
            m_EventModule.Fire(id);
        }
        #endregion
    }
}

