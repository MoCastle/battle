using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class NPCRunAdapt : NPCAnimAdapt
{
    [Header("走路速率")]
    public float rate = 1;
    protected override object GenState(Animator animator, BaseActorObj baseActorObj)
    {
        INPCRunAction enemyObj = base.GenState(animator, baseActorObj) as INPCRunAction;
        enemyObj.SetSpeedRate(rate);
        return enemyObj;
    }
}
