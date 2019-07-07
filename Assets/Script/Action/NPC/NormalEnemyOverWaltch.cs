using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class NormalEnemyOverWaltch : NpcBaseAction
{
    Vector3 targetPosition;
    Vector3 direction;
    public NormalEnemyOverWaltch(EnemyObj obj,SkillInfo skillInfo):base(obj, skillInfo)
    { }
    public override void Start()
    {
        base.Start();

        targetPosition = CountNextPoint();
        direction = targetPosition - npcActor.transform.position;
        direction.y = 0;
        direction = direction.normalized;
        owner.countTime = 0;
    }
    public override void End()
    {
        base.End();
        npcActor.FaceToDir(direction);
    }
    public override void Update()
    {
        SearchingPlayerByGuardArea();
    }
}
