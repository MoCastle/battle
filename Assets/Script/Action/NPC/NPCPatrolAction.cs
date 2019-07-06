using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class NPCPatrolAction : NPCRunAction {
    Vector3 patrolDirection;
    Vector3 targetPosition;
    public NPCPatrolAction(BaseActorObj obj,SkillInfo skillInfo):base(obj, skillInfo)
    {

    }
    public override void Start()
    {
        base.Start();
        targetPosition = CountNextPoint();
        patrolDirection = targetPosition - m_ActorObj.transform.position;
        m_ActorObj.FaceToDir(new Vector2(patrolDirection.x, 0));
    }

    public override void Update()
    {
        base.Update();
        Vector3 vector = targetPosition - m_ActorObj.transform.position;
        float distance = Vector3.Dot(vector, m_ActorObj.FaceDir);
        owner.distance = distance;
        SearchingPlayerByGuardArea();
    }
}
