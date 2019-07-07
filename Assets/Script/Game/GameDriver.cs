using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class GameDriver : MonoBehaviour {
    public RectTransform UI;
    private GameEntry m_GameEntry;
    [Header("是否编辑模式")]
    public bool isEditor;

    private void Awake()
    {
        m_GameEntry = GameEntry.Singleton;
    }

    private void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        m_GameEntry.Update();
    }
}
