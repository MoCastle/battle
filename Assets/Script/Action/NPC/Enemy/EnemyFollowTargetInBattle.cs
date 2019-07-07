using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class EnemyFollowTargetInBattle : EnemyBattleAction, INPCRunAction
{
    protected virtual float speed
    {
        get
        {
            return m_ActorPropty.moveSpeed;
        }
    }
    float m_SpeedRate = 1;
    float m_FaceSpaceTime=0.1f;
    float m_CountSpaceTime = 0;
    public EnemyFollowTargetInBattle(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
    }
    public void SetSpeedRate(float speedRate)
    {
        m_SpeedRate = speedRate;
    }

    public override void Update()
    {
        base.Update();
        m_ActorObj.Physic.SetSpeed(m_SpeedRate * m_ActorObj.propty.moveSpeed);
        if(m_CountSpaceTime<Time.time)
        {
            Vector3 faceDir = target.transform.position - m_ActorObj.transform.position;
            faceDir.y = 0;
            m_ActorObj.FaceToDir(faceDir);
            m_CountSpaceTime = Time.time + m_FaceSpaceTime;
        }
    }
}
