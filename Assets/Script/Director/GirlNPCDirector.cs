using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using GameScene;

public class GirlNPCDirector : MonoBehaviour {
    public TheNPC nPC;
    public GirlAnimator m_GirAnimator;
    int enterGameHash;
    public GameObject playerNpc;
    public GameObject player;
    public EnemyObj boss;
    public bool bossDead;
    public DialogObj dialog;

    float time;

    private void Awake()
    {
        InputManager.Singleton.PauseInput();
        boss.onDeath += onBossDead;
        dialog.enterTrigerAction += OnEnterTrigger;
        dialog.leaveTrigerAction += OnLeaveTrigger;
        m_GirAnimator.onGameEnd += OnRealyEndGame;
    }
    
    void OnEnterTrigger( PlayerObj player)
    {
        if(bossDead)
        {
            nPC.OnDialog(1);
        }else
        {
            time = Time.time + 4;
        }
    }
    void OnLeaveTrigger(PlayerObj player)
    {
        time = -1;
    }
    void onGameEndTalk()
    {
        player.active = false;
        m_GirAnimator.animator.SetTrigger("end");
    }

    // Use this for initialization
    void Start () {
        m_GirAnimator.onStarGametend += StartEnterGame;
        nPC.DialogInfos[0].onDialogEnd = StartDialogEnd;
        nPC.DialogInfos[1].onDialogEnd = onGameEndTalk;
        nPC.OnDialog();
    }
    public void StartDialogEnd()
    {
        m_GirAnimator.animator.SetTrigger("dialogComplete");
        playerNpc.active = false;
        player.active = true;
        InputManager.Singleton.ContinueInput();
    }
    public void onBossDead()
    {
        bossDead = true;
    }
    public void EnterGame()
    {

    }
    public void StartEnterGame()
    {
        playerNpc.active = false;
        player.active = true;
        m_GirAnimator.onGameEnd += OnRealyEndGame ;
    }
    void OnRealyEndGame()
    {
        Animator animator = GetComponent<Animator>();
        if(bossDead)
        {
            animator.SetTrigger("badend");
        }
        else
        {
            animator.SetTrigger("goodend");
        }
    }
    // Update is called once per frame
    void Update () {
		if(time > 0&&(time - Time.time <0))
        {
            time = -1;
            onGameEndTalk();
        }
	}
}
