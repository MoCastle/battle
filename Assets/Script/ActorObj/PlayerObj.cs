using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace GameScene
{
    public class PlayerObj : BaseActorObj
    {
        public List<FriendlyNPC> friendlyNPCList;
        #region 内部属性
        InputInfo m_CurOrder;
        public bool pushed;
        public bool dialogStarted;
        #endregion

        #region 对外接口
        public InputInfo CurOrder
        {
            get
            {
                return m_CurOrder;
            }
        }
        #endregion
        protected override void Init()
        {
            m_IDLayer = LayerMask.GetMask("Enemy");//1 << LayerMask.NameToLayer("Enemy");
            m_ActionCtrler = new ActionCtrler(this, m_CharacterAnim.Animator);//, info.ActorActionList);
            pushed = false;
            dialogStarted = false;
            friendlyNPCList = new List<FriendlyNPC>();
        }
        #region 手势获取

        //通过手势获取输入
        public InputInfo GetInputByGesture(HandGesture gesture)
        {
            return LegalnputDict[gesture];
        }
        Dictionary<HandGesture, InputInfo> LegalnputDict = new Dictionary<HandGesture, InputInfo>();
        public override void EnterState()
        {
            //ClearAnimParam();
        }

        public override void LogicUpdate()
        {

            if (Alive)
            {
                foreach(KeyValuePair<KeyCode,bool> keyValuePair in InputManager.Singleton.keyDictionary)
                {
                    switch(keyValuePair.Key)
                    {
                        case KeyCode.Space:
                            if(keyValuePair.Value)
                            {
                                if (!dialogStarted)
                                {
                                    dialogStarted = true;
                                    StartDialog();
                                }
                            }
                            else
                            {
                                dialogStarted = false;
                            }
                            break;
                        case KeyCode.S:
                            if (keyValuePair.Value)
                            {
                                if (!pushed)
                                {
                                    pushed = true;
                                    ActionCtrl.SetBool(keyValuePair.Key.ToString(), keyValuePair.Value);
                                }
                            }
                            else
                            {
                                pushed = false;
                            }
                            break;
                        default:
                            ActionCtrl.SetBool(keyValuePair.Key.ToString(), keyValuePair.Value);
                            break;
                    }
                }
                if(InputManager.Singleton.keyDictionary[KeyCode.LeftArrow]||InputManager.Singleton.keyDictionary[KeyCode.RightArrow])
                {
                    Vector2 dir = new Vector2();
                    if(InputManager.Singleton.keyDictionary[KeyCode.LeftArrow])
                    {
                        dir = Vector2.left;
                    }
                    else
                    {
                        dir = Vector2.right;
                    }
                    ActionCtrl.CurAction.InputDirect(dir);
                }
            }
        }
        #endregion
        #region 对话
        public void StartDialog()
        {
            if( friendlyNPCList.Count>0)
            {
                friendlyNPCList[0].OnDialog();
            }
        }
        #endregion
        #region 事件
        public override void SwitchAction(BaseAction baseAction)
        {
            base.SwitchAction(baseAction);
        }

        #endregion
    }
}

