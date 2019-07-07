using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;
using GameScene;

public class EnemyBattleAction : NpcBaseAction
{
    protected PlayerObj target;
    public EnemyBattleAction(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
    }
    public override void Start()
    {
        base.Start();
        target = owner.target as PlayerObj;
    }
    public override void Update()
    {
        base.Update();
        Vector3 disVector = target.transform.position - m_ActorObj.transform.position;
        disVector.y = 0;
        float distance = disVector.magnitude;
        owner.distance = distance;
    }
}
