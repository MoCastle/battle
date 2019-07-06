using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;
using FrameWorkModule;
using FrameWorkModule.Resource;

namespace GameManager
{
    public class GameResourceManagertest :BaseGameManager<GameResourceManagertest>  {
        public GameResourceManagertest()
        {
            //FrameWorkEntry m_FrameWork = GameEntry.Singleton.FrameWork;
            if (GameEntry.Singleton.IsEditor)
            {
                //m_FrameManager = new EditorResourceManager();
                //m_FrameWork.AddManager<EditorResourceManager>(m_FrameManager as EditorResourceManager);
            }
            else
            {
               // m_FrameManager = new ResourceManager();
                //m_FrameWork.AddManager<ResourceManager>(m_FrameManager as ResourceManager);
            }
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        public void LoadScene(string name,LoadSceneCallbacks callback)
        {
           // m_FrameManager.LoadScene(name, callback);
        }

        public override void Start()
        {
            throw new System.NotImplementedException();
        }

        //protected override void SetFrameManager()
        //{
        //    FrameWorkEntry frmWork = GameEntry.Singleton.FrameWork;
        //    if (GameEntry.Singleton.IsEditor)
        //    {
        //        EditorResourceManager resourceManager = new EditorResourceManager();
        //        //frmWork.AddManager<EditorResourceManager>(resourceManager);
        //        m_FrameManager = resourceManager;
        //    }
        //    else
        //    {
        //        ResourceManager resourceManager = new ResourceManager();
        //        //frmWork.AddManager<ResourceManager>(resourceManager);
        //        m_FrameManager = resourceManager;
        //    }
        //}
    }
}

