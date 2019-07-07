using System.Collections;
using System.Collections.Generic;
using GameScene;
using UnityEngine;

public class JumpAction : PlayerAction
{
    float m_Speed;
    public JumpAction(BaseActorObj baseActorObj, SkillInfo skillInfo) : base(baseActorObj, skillInfo)
    {
        m_ActorObj.SetImdVSpeed(120);
    }
    public override void Start()
    {
        base.Start();
        //m_ActorObj.SetMoveSpeed( Vector2.up * m_VSpeed)
    }

    float speed
    {
        get
        {
            return m_ActorPropty.moveSpeed*0.4f;
        }
    }
    public override void InputDirect(Vector2 dirction)
    {
        base.InputDirect(dirction);
        if(Mathf.Abs(dirction.x)>0)
        {
            m_ActorObj.SetImdHSpeed(speed);
            m_Speed = dirction.x / Mathf.Abs(dirction.x) * speed;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        m_ActorObj.SetSpeed(m_Speed);
    }

    public override void InputNormInput(InputInfo curInput)
    {
        base.InputNormInput(curInput);
    }
}
