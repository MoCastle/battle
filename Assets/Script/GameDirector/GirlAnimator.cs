using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAnimator : MonoBehaviour {
    public Animator animator;
    public Action<int> onStartClip;
    public Action<int> onEndClip;
    public Action onStarGametend;
    public Action onEnterGame;
    public Action onGameEnd;

    public void OnGameEnd()
    {
        if (onGameEnd != null)
        {
            onGameEnd();
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void StartGame()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);//.IsName("Base Layer.Attack1")
        if (onStartClip != null)
        {
            onStartClip(stateInfo.tagHash);
        }
    }

    public void StartGameEnd()
    {
        if (onStarGametend != null)
        {
            onStarGametend();
        }
    }
    public void EnterGame()
    {
        if (onEnterGame != null)
        {
            onEnterGame();
        }
    }
}
