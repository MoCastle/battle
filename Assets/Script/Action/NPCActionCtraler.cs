using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class NPCActionControler : ActionCtrler
{
    private BaseActorObj m_CurTarget;
    private bool m_InBattle;
    private float m_Distance;
    private float m_Life;
    private float m_CountTime;
    #region 属性
    public NPCObj npcActor
    {
        get
        {
            return m_ActorObj as NPCObj;
        }
    }
    public float life
    {
        get
        {
            return m_Life;
        }
        set
        {
            if (value != m_Life)
            {
                npcActor.animator.SetFloat("Life", m_Distance);
                m_Life = value;
            }
        }
    }
    public float distance
    {
        get
        {
            return m_Distance;
        }
        set
        {
            if (value != m_Distance)
            {
                npcActor.animator.SetFloat("CountDistance", m_Distance);
                m_Distance = value;
            }
        }
    }
    public bool inBattle
    {
        get
        {
            return m_InBattle;
        }
        set
        {
            npcActor.animator.SetBool("inBattle", value == null ? false : true);
            m_InBattle = value;
        }
    }
    public BaseActorObj target
    {
        get
        {
            return m_CurTarget;
        }
        set
        {
            npcActor.animator.SetBool("getTarget", value == null ? false : true);
            m_CurTarget = value;
        }
    }
    public float countTime
    {
        get
        {
            return m_CountTime;
        }
        set
        {
            if (m_CountTime == value)
            {
                return;
            }
            npcActor.animator.SetFloat("CountTime", value);
            m_CountTime = value;
        }
    }
    public float timeTamp;
    public Vector3 leftGuardPoint;
    public Vector3 rightGuardPoint;
    public bool attackLost
    {
        set
        {
            npcActor.animator.SetBool("attackLost", value);
        }
    }
    #endregion

    public NPCActionControler(EnemyObj enemyObj) : base(enemyObj, enemyObj.animator)
    {
        Vector2 guardSize = enemyObj.guardSize;
        Vector2 shift = enemyObj.guardShiftValue;
        Vector2 position = enemyObj.guartPoint;
        leftGuardPoint = position + shift;
        leftGuardPoint.z = npcActor.transform.position.z;
        rightGuardPoint = leftGuardPoint;
        leftGuardPoint.x -= guardSize.x / 2;
        rightGuardPoint.x += guardSize.x / 2;
    }
    public override void Update()
    {
        base.Update();
        countTime = timeTamp - Time.time;
    }
}
