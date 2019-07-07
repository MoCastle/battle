using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;

public class InputManager : BaseSingleton<InputManager> {
    Dictionary<KeyCode, bool> m_InputDict;
    KeyCode[] m_KeyList;
    bool m_Paused;
    public KeyCode[] keyList
    {
        get
        {
            return m_KeyList;
        }
    }

    public Dictionary<KeyCode, bool> keyDictionary
    {
        get
        {
            return m_InputDict;
        }
    }

    public InputManager()
    {
        m_KeyList = new KeyCode[] { KeyCode.LeftArrow, KeyCode.RightArrow,KeyCode.S,KeyCode.A, KeyCode.UpArrow,KeyCode.Space };
        m_InputDict = new Dictionary<KeyCode, bool>();
        foreach(KeyCode keyCode in m_KeyList)
        {
            m_InputDict.Add(keyCode, false);
        }
        m_Paused = false;
    }

    public void InputKeyCode(KeyCode keyInput)
    {
        if (m_Paused)
            return;
        if(keyDictionary[keyInput]!= true)
            keyDictionary[keyInput] = true;
    }

    public void CancelKeyCode(KeyCode keyInput)
    {
        if (keyDictionary[keyInput] != false)
            keyDictionary[keyInput] = false;
    }

    public void PauseInput()
    {
        m_Paused = true;
    }
    public void ContinueInput()
    {
        m_Paused = false;
    }
}

