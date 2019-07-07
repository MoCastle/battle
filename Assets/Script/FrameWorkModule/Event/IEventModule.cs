using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameWorkModule
{
    public interface IEventModule
    {
        #region 事件
        void Regist(int id, EventHandler func);
        void UnRegist(int id, EventHandler handler);
        void Fire(int id);
        #endregion
    }
}

