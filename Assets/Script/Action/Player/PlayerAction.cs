using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;

public class PlayerAction : BaseAction {
    protected InputInfo m_Input;
    protected PlayerObj m_PlayerObj;
	public PlayerAction(BaseActorObj baseActorObj, SkillInfo skillInfo):base(baseActorObj, skillInfo)
    {
        m_PlayerObj = baseActorObj as PlayerObj;
        SetStartDirection();
        m_PlayerObj.ClearAnimParam();
    }
    public virtual void SetStartDirection()
    {
        if(m_DirLock)
        {
            return;
        }
        m_Input = m_PlayerObj.CurOrder;
        Vector2 gestureDir = m_Input.vector;
        //方向设置
        switch (m_Input.gesture)
        {
            case HandGesture.Slip:
                gestureDir.y = 0;
                m_PlayerObj.FaceToDir(gestureDir);
                Debug.Log(gestureDir);
                break;
            case HandGesture.Click:
                float dirX = 0;
                dirX = m_Input.endPS.x - Screen.width / 2;
                gestureDir.y = 0;
                m_PlayerObj.FaceToDir(gestureDir);
        break;
        }
    }

    public virtual void InputNormInput(InputInfo curInput )
    {
        float xValue = 0;
        
        switch (curInput.gesture)
        {
            case HandGesture.Click:
                float dirX = 0;
                //xValue = curInput.InputInfo.EndPs.x - _Input.InputInfo.EndPs.x;
                xValue = m_Input.endPS.x - Screen.width / 2;
                break;
            case HandGesture.Drag:
            case HandGesture.Slip:
            case HandGesture.Holding:
                xValue = curInput.vector.x;
                break;
        }
        if(xValue!=0)
        {
            InputDirect(Vector2.right * xValue / Mathf.Abs(xValue));
        }
            
    }
}
