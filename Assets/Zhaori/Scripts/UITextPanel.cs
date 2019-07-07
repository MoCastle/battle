using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UITextPanel : MonoBehaviour, UIPanel
{


    [Tooltip("文字出现时间")]
    public float FadeTime = 1;

    public Text Content;

    public Image Player;

    public Image Target;
    int count = 0;
    int clickCount = 0;


    private void OnEnable()
    {
        InitText();

    }


    public void Init()
    {

    }

    private void InitText()
    {
        Player.gameObject.SetActive(false);
        Target.gameObject.SetActive(false);
        Content.transform.localPosition = new Vector3(0, -10, 0);
        Content.text = "";
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_IsNormalFrame)
            {
                count = 0;
                clickCount = 0;
                Next();
            }
            else
            {
                ++clickCount;
                if (clickCount >= 3)
                {
                    CompleteDialog();
                    if(mForceCompelete!= null)
                    {
                        mForceCompelete();
                    }
                }
            }
        }
    }

    private string[] mContent;

    private int Current = -1;

    private bool m_IsNormalFrame = false;

    private Action mOnCompelete;
    private Action mForceCompelete;

    public void StartTalk(string[] contents, Action OnCompelete = null, Action forceComplete = null)
    {


        mContent = contents;
        mOnCompelete = OnCompelete;
        mForceCompelete = forceComplete;
        count = 0;
        Next();
    }

    private void Next()
    {
        clickCount = 0;
        Current++;
        m_IsNormalFrame = false;
        if (Current >= mContent.Length)
        {
            CompleteDialog();
            return;
        }
        InitText();
        SetTextContent(mContent[Current]);

    }

    private void CompleteDialog()
    {
        mContent = null;
        Current = -1;
        InitText();
        gameObject.SetActive(false);

        if (mOnCompelete != null)
        {
            mOnCompelete.Invoke();
            mOnCompelete = null;
        }
    }

    private void SetTextContent(string content)
    {
        Content.DOFade(0, 0);

        string[] splits = content.Split('|');
        Content.text = splits[1];
        string name = splits[0];

        Sprite sprite = Resources.Load<Sprite>("HeadSprite/" + name);

        if (name == "Player")
        {
            Player.sprite = sprite;
            Player.gameObject.SetActive(true);
        }
        else
        {
            Target.sprite = sprite;
            Target.gameObject.SetActive(true);
        }
        Content.DOFade(1, FadeTime).OnComplete(
            () =>
            {
                m_IsNormalFrame = true;
            });
        Content.transform.DOLocalMoveY(0, FadeTime);

    }

}
