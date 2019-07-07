using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class NPCAttack : EnemyBattleAction
{
    bool attackSuccess;
    public NPCAttack(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
    }
    public override void Start()
    {
        base.Start();
        attackSuccess = false;
        owner.attackLost = true;
    }
    public override Collider2D[] GetAttackList()
    {
        Collider2D[] attackList = base.GetAttackList();
        if(attackList[0]!=null)
        {
            owner.attackLost = false;
        }
        return attackList;
    }
}
