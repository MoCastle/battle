using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach( KeyCode keyCode in InputManager.Singleton.keyList)
        {
            if (Input.GetKey(keyCode))
            {
                InputManager.Singleton.InputKeyCode(keyCode);
            }else
            {
                InputManager.Singleton.CancelKeyCode(keyCode);
            }
        }
	}
}
