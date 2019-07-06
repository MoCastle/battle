using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class NPCAnimAdapt : AnimAdapt
{
    public float maxRandomTime = -1;
    public float minRandomTime = -1;
    public int dialogID = -1;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        EnemyObj enemyObj = BaseActorObj.GetActorByAnimatorTransform(animator.transform) as EnemyObj;
        NPCActionControler npcActionControler = enemyObj.actionControler;
        if(dialogID>=0 && enemyObj.curDialogID!=dialogID)
        {
            enemyObj.SayDialog(dialogID);
        }
        if (maxRandomTime > 0 && minRandomTime > 0) 
        {
            float randomTime = maxRandomTime == minRandomTime ? maxRandomTime : (maxRandomTime - minRandomTime) * Random.value + minRandomTime;
            npcActionControler.timeTamp = Time.time + randomTime;
        }
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        animator.SetFloat("randomValue", Random.value);

    }
}
