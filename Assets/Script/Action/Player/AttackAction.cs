﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;
//玩家普通三连技能
public class AttackAction : PlayerAction {

	public AttackAction(BaseActorObj baseActorObj, SkillInfo skillInfo) :base(baseActorObj, skillInfo)
    {
    }
    public override void Start()
    {
        base.Start();
        m_ActorObj.ActionCtrl.SetBool(KeyCode.S.ToString(), false);
    }

}
