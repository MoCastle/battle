using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class EnemyEnterBattleAction : NpcBaseAction
{
    public EnemyEnterBattleAction(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
    }
    public override void Start()
    {
        base.Start();
        owner.inBattle = true;
    }
}
