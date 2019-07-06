using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using GameScene;

public class EnemyObj : NPCObj
{
    
    
    #region 临时功能
    public Slider _LifeSlider;
    public Slider LifeSlider
    {
        get
        {
            if (_LifeSlider == null)
            {
                _LifeSlider = transform.Find("WorldCanvas").Find("LifeSlide").GetComponent<Slider>();
            }
            return _LifeSlider;
        }
    }
    #endregion
    #region 属性
    
    #endregion

    #region 对外接口
    
    #endregion
    #region 流程
    protected override void Init()
    {
        m_Animator = transform.Find("Animator").GetComponent<Animator>();
        m_IDLayer = 1 << LayerMask.NameToLayer("Player");

        Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集 
        m_IDLayer = 1 << LayerMask.NameToLayer("Player");
        m_ActionCtrler = new NPCActionControler(this);
    }
    #endregion
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //LifeSlider.value = m_ActorPropty.percentLife;
    }

    void ClearAnimParams()
    {
        AnimatorControllerParameter[] animParams = ActionCtrl.GetAnimParams;
        foreach(AnimatorControllerParameter param in animParams)
        {
            if (param.type == AnimatorControllerParameterType.Bool && param.name != "IsOnGround" && param.name != "IsJustOnGround")
            {
                ActionCtrl.SetBool(param.name,false);
            }
        }
    }

    #region 事件
    public override void OnBeBreak()
    {
    }
    #endregion
}
