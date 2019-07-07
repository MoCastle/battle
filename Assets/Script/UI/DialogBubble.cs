using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dialog;
using UnityEngine.UI;
namespace GameScene
{
    public class DialogBubble : MonoBehaviour
    {
        [Header("每行字数")]
        public int lineWards=6;
        float m_TimeCount;
        DialogLine m_CurLine;
        ActorDialogInfo m_DialogInfo;
        bool m_IsShowing;
        Animator m_BubbleAnimator;
        Text text;
        Font m_Font;
        RectTransform m_Transform;
        Vector2 m_AnchorSize;
        float m_YPosition;

        int m_DialogID = -1;
        public int dialogID
        {
            get
            {
                return m_DialogID;
            }
        }

        bool showing
        {
            get
            {
                return m_IsShowing;
            }
            set
            {
                if (m_IsShowing == value)
                    return;
                m_IsShowing = value;
                GetComponent<Animator>().SetBool("showing", value);
            }
        }
        public void Awake()
        {
            m_Transform = GetComponent<RectTransform>();
            m_YPosition = m_Transform.localPosition.y;

            m_BubbleAnimator = GetComponent<Animator>();
            text = m_Transform.Find("Text").GetComponent<Text>();

            RectTransform textTransform = text.GetComponent<RectTransform>();
            m_Font = text.font;
            m_AnchorSize.x = 1-(textTransform.rect.xMax);
            m_AnchorSize.y = 1 - (textTransform.rect.yMax);

        }

        public void Say(ActorDialogInfo dialogInfo)
        {
            m_DialogInfo = dialogInfo;
            m_DialogID = dialogInfo.type;
            DialogSay();
            
        }

        private void DialogSay()
        {
            int randomValue = (int)(Random.value * m_DialogInfo.linesInfo.Length);
            DialogLine line = m_DialogInfo.linesInfo[randomValue];
            m_CurLine = line;
            m_TimeCount = Time.time + m_CurLine.continueTime;
            text.text = m_CurLine.dialogConversation.Replace('#','\n');
            CountBubbleSize();
            showing = true;
        }


        private void CountBubbleSize()
        {
            string dialogText = text.text;
            int countLineWords = 0;
            float height = 0;
            float width = 0;
            for(int idx = 0;idx <dialogText.Length;++idx)
            {
                if(dialogText[idx] == '\n')
                {
                    countLineWords = 0;
                    ++height;
                }else
                {
                    if (countLineWords > lineWards)
                    {
                        dialogText.Insert(idx, "\n");
                    }
                    ++countLineWords;
                }
            }
            text.text = dialogText;
            //height *= text.preferredHeight;
            //height += 2 * m_AnchorSize.y;
            //width = 2 * m_AnchorSize.x + lineWards * text.preferredWidth/**/;
            //m_Transform.sizeDelta = new Vector2(width, height);
            //Vector3 ps = m_Transform.localPosition;
            //ps.y = m_YPosition + height / 2;
            //m_Transform.localPosition = ps;
        }

        public void DialogBreak()
        {
            showing = false;
            if (m_DialogInfo.spaceTime > 0)
            {
                m_TimeCount = Time.time + m_DialogInfo.spaceTime;
            }else
            {
                m_DialogID = -1;
            }
        }

        public void Update()
        {
            if ( m_TimeCount>0 && m_TimeCount < Time.time)
            {
                m_TimeCount = -1;
                if(showing)
                {
                    DialogBreak();
                }
                else
                {
                    DialogSay();
                }
            }
        }
    }
}

