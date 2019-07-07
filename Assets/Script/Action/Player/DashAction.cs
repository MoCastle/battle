using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class DashAction : PlayerAction {
    public DashAction(BaseActorObj baseActorObj, SkillInfo skillInfo) :base(baseActorObj, skillInfo)
    {
    }
    public override void Start()
    {
        base.Start();
        m_ActorObj.ActionCtrl.SetBool(KeyCode.S.ToString(),false);
    }
}
