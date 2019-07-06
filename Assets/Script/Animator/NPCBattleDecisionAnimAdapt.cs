using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;
public class NPCBattleDecisionAnimAdapt : NPCAnimAdapt
{
    //public float randomNum;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BaseActorObj NoticeObject = animator.gameObject.GetComponentInParent<BaseActorObj>();
        NPCBattleDicesion state = new NPCBattleDicesion(NoticeObject, SkillInfo); // 创建类的实例，返回为 object 类型，需要强制类型转换
        NoticeObject.SwitchAction(state);
    }
}
