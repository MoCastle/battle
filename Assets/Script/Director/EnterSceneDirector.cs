using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class EnterSceneDirector : Director {
    public BaseActorObj player;
    public BaseActorObj npc;

    public Transform playerStartPosition;
    public Transform npcStartPosition;
    public Transform playerEndPosition;
    public Transform npcEndPosition;
    public float time;
	// Use this for initialization
	void Start () {

    }
}
