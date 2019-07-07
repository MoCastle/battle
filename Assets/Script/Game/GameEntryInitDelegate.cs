using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameManager
{
    public class GameEntryInitDelegate
    {
        public bool rungning;
        IEnumerator<IGameManager> m_ManagerEnumerator;

        public Action onInitComplete;
        private GameDriver m_Driver;

        public GameEntryInitDelegate( GameDriver driver )
        {
            rungning = true;
            m_Driver = driver;
            Start();
        }

        // Use this for initialization
        void Start()
        {
            GameEntry gameEntry = GameEntry.Singleton;
            gameEntry.driver = m_Driver;
            gameEntry.AddGameMaanager(GameEventManager.Singleton);
            gameEntry.AddGameMaanager(GameUIManager.Singleton);
            //gameEntry.AddGameMaanager(GameResourceManager.Singleton);
            gameEntry.Init();

            List<IGameManager> gameManagers = new List<IGameManager>();
            m_ManagerEnumerator = gameEntry.GetGameManagerEnumerator();
            m_ManagerEnumerator.Reset();
            while (m_ManagerEnumerator.MoveNext())
            {
                gameManagers.Add(m_ManagerEnumerator.Current);
            }
            gameManagers.Sort(SortManager);
            m_ManagerEnumerator = gameManagers.GetEnumerator();
            m_ManagerEnumerator.Reset();
            if(! m_ManagerEnumerator.MoveNext())
            {
                onInitComplete();
            }
        }

        int SortManager(IGameManager pre, IGameManager next)
        {
            if(pre.priority > next.priority)
            {
                return 1;
            }
            if(pre.priority<next.priority)
            {
                return -1;
            }
            return 0;
        }
        // Update is called once per frame
        public void Update()
        {
            if(rungning==false)
            {
                return;
            }

            if(!m_ManagerEnumerator.Current.started)
            {
                if(!m_ManagerEnumerator.Current.starting)
                {
                    m_ManagerEnumerator.Current.Start();
                }
            }else if(!m_ManagerEnumerator.MoveNext())
            {
                rungning = false;
                onInitComplete();
            }
        }
    }
}

