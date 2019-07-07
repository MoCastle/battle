using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using GameScene;

public class BattleSceneDirector : MonoBehaviour {
    public FriendlyNPC npc;
    public EnemyObj enemy;
    public PlayerObj player;
    public GameObject PlayerLifeBar;
    public GameObject wall;
	// Use this for initialization
	void Start () {
        npc.DialogInfos[0].onDialogEnd = OnBattleStart;
        enemy.onDeath = OnEnemyDeath;
        player.onDeath = OnPlayerDeath;
    }
    public void OnBattleStart()
    {
        npc.gameObject.active = false;
        enemy.gameObject.active = true;
        PlayerLifeBar.active = true;
        enemy.SetTarget(player);
        wall.active = true;
    }

    public void OnEnemyDeath()
    {
        PlayerLifeBar.active = false;
        wall.active = false;
    }

    public void OnPlayerDeath()
    {
        Debug.Log("PlayerLost");

    }
}
