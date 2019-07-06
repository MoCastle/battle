using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameManager
{
    public interface IGameManager
    {
        bool started
        {
            get;
        }
        bool starting
        {
            get;
        }

        int priority
        {
            get;
        }

        void Init();
        void Start();
    }
}

