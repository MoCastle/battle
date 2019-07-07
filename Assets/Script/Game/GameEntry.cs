using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWorkModule;
using BaseFunc;
namespace GameManager
{
    public class GameEntry : BaseSingleton<GameEntry>
    {
        #region 变量
        private GameDriver m_DriverObject;
        private FrameWorkEntry m_FrameWorkEntry;
        private LinkedList<IGameManager> m_MgrList;
        #endregion 
        #region 接口
        internal GameDriver driver
        {
            get
            {
                return m_DriverObject;
            }
            set
            {
                m_DriverObject = value;
            }
        }
        internal LinkedList<IGameManager> managers
        {
            get
            {
                return m_MgrList;
            }
        }
        public bool IsEditor { get; set; }
        public bool started
        {
            get
            {
                if(m_MgrList.Count<1)
                {
                    return true;
                }
                bool started = false;
                foreach (IGameManager mgr in m_MgrList)
                {
                    if (mgr.started == false)
                    {
                        started = false;
                        break;
                    }
                }
                return started;
            }
        }
        #endregion
        #region 流程
        public GameEntry() : base()
        {
            m_FrameWorkEntry = new FrameWorkEntry();
            m_MgrList = new LinkedList<IGameManager>();

            IsEditor = true;
        }

        public void Init()
        {
            foreach (IGameManager mgr in m_MgrList)
            {
                mgr.Init();
            }
        }

        public void Update()
        {
            m_FrameWorkEntry.Update();
        }
        #endregion
        #region 模块操作
        internal T GetModule<T> () where T: BaseFrameWorkModule,new()
        {
            return m_FrameWorkEntry.GetModule<T>() as T;
        }
        #endregion
        #region 经理管理
        internal void AddGameMaanager(IGameManager gameManager)
        {
            m_MgrList.AddFirst(gameManager);
        }
        internal IEnumerator<IGameManager> GetGameManagerEnumerator()
        {
            return m_MgrList.GetEnumerator();
        }

        #endregion
    }
}

