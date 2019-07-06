using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
namespace GameScene
{
    public class StartSceneDirector : MonoBehaviour
    {
        public string startSceneName;
        private GameEntry m_Entry;
        private GameEntryInitDelegate initer;
        // Use this for initialization
        void Start()
        {
            m_Entry = GameEntry.Singleton;
            initer = new GameEntryInitDelegate(GameObject.Find("Driver").GetComponent<GameDriver>());
            initer.onInitComplete = onInitComplete;
        }

        public void onInitComplete()
        {
            Debug.Log("InitComplete");
        }

        // Update is called once per frame
        void Update()
        {
            initer.Update();
        }
        
    }
}

