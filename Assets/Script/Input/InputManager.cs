using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseFunc;

public class InputManager : BaseSingleton<InputManager> {
    Dictionary<KeyCode, bool> m_InputDict;
    KeyCode[] m_KeyList;
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
        m_KeyList = new KeyCode[] { KeyCode.A, KeyCode.D,KeyCode.W};
        m_InputDict = new Dictionary<KeyCode, bool>();
        foreach(KeyCode keyCode in m_KeyList)
        {
            m_InputDict.Add(keyCode, false);
        }
    }



    public void InputKeyCode(KeyCode keyInput)
    {
        if(keyDictionary[keyInput]!= true)
            keyDictionary[keyInput] = true;
    }

    public void CancelKeyCode(KeyCode keyInput)
    {
        if (keyDictionary[keyInput] != false)
            keyDictionary[keyInput] = false;
    }
}

