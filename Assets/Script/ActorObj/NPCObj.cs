using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;
public abstract class NPCObj : BaseActorObj
{
    #region 编辑
    void OnDrawGizmos()
    {
        Gizmos.color = guardDrawColor;//为随后绘制的gizmos设置颜色。
        Gizmos.DrawCube((Vector3)guartPoint + guardShiftValue, guardSize);
    }
    #endregion
    #region 变量
    [SerializeField]
    [Header("守卫区域")]
    BoxCollider2D _GuardBox;
    protected Animator m_Animator;

    [Header("巡逻点")]
    public Vector2 guartPoint;
    [Header("巡逻范围")]
    public Vector2 guardSize;
    [Header("偏移量")]
    public Vector3 guardShiftValue;
    public Color guardDrawColor;

    BoxCollider2D[] _ColliderList;
    #endregion
    #region 属性
    public BoxCollider2D GuardinArea
    {
        get
        {
            return _GuardBox;
        }
    }
    public Animator animator
    {
        get
        {
            return m_Animator;
        }
    }
    //堆对象缓存 提快计算速度
    public NPCActionControler actionControler
    {
        get
        {
            return m_ActionCtrler as NPCActionControler;
        }
    }
    #endregion
    #region 流程
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    #endregion
    #region AI
    //寻找敌人
    public Collider2D[] FindEnemy(int Layer)
    {
        if (!GuardinArea.enabled)
        {
            return null;
        }
        if (_ColliderList == null)
        {
            _ColliderList = new BoxCollider2D[5];
        }
        ContactFilter2D _contactFilter = new ContactFilter2D();
        _contactFilter.SetLayerMask(Layer);
        GuardinArea.OverlapCollider(_contactFilter, _ColliderList);
        return _ColliderList;
    }
    #endregion
}
