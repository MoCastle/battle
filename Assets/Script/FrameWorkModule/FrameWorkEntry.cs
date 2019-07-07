using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;

namespace FrameWorkModule
{
    public class FrameWorkEntry
    {
        #region 内部属性
        Dictionary<string, BaseFrameWorkModule> m_FMDict;
        LinkedList<BaseFrameWorkModule> m_FMManagerList;
        #endregion
        
        public FrameWorkEntry() : base()
        {
            m_FMDict = new Dictionary<string, BaseFrameWorkModule>();
            m_FMManagerList = new LinkedList<BaseFrameWorkModule>();
        }
        public T AddManager<T>() where T : BaseFrameWorkModule,new ()
        {
            Type type = typeof(T);
            T manager = new T();
            m_FMDict.Add(type.Name, manager);
            return manager;
        }

        public void Update()
        {
            m_FMManagerList.Clear();
            foreach (KeyValuePair<string, BaseFrameWorkModule> keyValue in m_FMDict)
            {
                m_FMManagerList.AddFirst(keyValue.Value);
            }
            foreach (BaseFrameWorkModule mgr in m_FMManagerList)
            {
                mgr.Update();
            }
        }

        internal T GetModule<T>()where T:BaseFrameWorkModule,new ()
        {
            Type type = typeof(T);
            BaseFrameWorkModule manager = null;
            if( !m_FMDict.TryGetValue(type.Name,out manager))
            {
                manager = AddManager<T>();
            }
            return manager as T;
        }
    }
}


