using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameScene
{
    public class DialogUI
    {
        DialogBubble m_DialogBubble;
        public DialogBubble dialogBubble
        {
            get
            {
                return m_DialogBubble;
            }
        }
        public int dialogID
        {
            get
            {
                return m_DialogBubble.dialogID;
            }
        }

        public DialogUI( BaseActorObj actorObj,RectTransform dialogUI = null )
        {
            if(dialogUI == null)
            {
                RectTransform dialogModle = Resources.Load<RectTransform>("Prefab/worldUI/Dialog");
                dialogUI = GameObject.Instantiate<RectTransform>(dialogModle);
                BoxCollider2D bodySize = actorObj.BodyCollider;
                Vector3 position = actorObj.transform.position;
                position.y += bodySize.size.y * 1.3f;
                dialogUI.transform.position = position;
            }
            dialogUI.SetParent(actorObj.transform);

            m_DialogBubble = dialogUI.Find("Bubble").GetComponent<DialogBubble>();
        }
        
    }
}

