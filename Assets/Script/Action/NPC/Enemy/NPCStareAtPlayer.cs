using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class NPCStareAtPlayer : EnemyBattleAction
{
    public NPCStareAtPlayer(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
    }
    public override void Update()
    {
        base.Update();
        Vector3 disVector = target.transform.position - m_ActorObj.transform.position;
        disVector.y = 0;
        m_ActorObj.FaceToDir(disVector);
    }
}
