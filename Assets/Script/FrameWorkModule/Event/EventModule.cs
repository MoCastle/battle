﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule;

namespace FrameWorkModule.Event
{
    public class EventModule : BaseFrameWorkModule,IEventModule
    {
        #region 字段
        Dictionary<int, List<EventHandler>> m_EventDict;
        #endregion
        #region 流程
        public EventModule() : base()
        {
            m_EventDict = new Dictionary<int, List<EventHandler>>();
        }

        public override void Start()
        {
        }

        public override void Update()
        {
            foreach (KeyValuePair<int, List<EventHandler>> keyValue in m_EventDict)
            {
                List<EventHandler> handlerList = keyValue.Value;
                foreach (EventHandler runHandler in handlerList)
                {
                    EventArgs e = new EventArgs();
                    runHandler(null, e);
                }
            }
        }
        #endregion
        #region 事件
        public void Regist(int id, EventHandler handler)
        {
            List<EventHandler> handlerList = null;
            if (!m_EventDict.TryGetValue(id, out handlerList))
            {
                handlerList = new List<EventHandler>();
                m_EventDict.Add(id, handlerList);
            }
            handlerList.Add(handler);
        }

        public void UnRegist(int id, EventHandler handler)
        {
            List<EventHandler> handlerList = null;
            if (!m_EventDict.TryGetValue(id, out handlerList))
            {
                return;
            }
            handlerList.Remove(handler);
        }

        public void Fire(int id)
        {
            List<EventHandler> handlerList = null;
            if (m_EventDict.TryGetValue(id, out handlerList))
            {
                foreach (EventHandler handler in handlerList)
                {
                    handler(null, null);
                }
            }
        }
        #endregion
    }
}

