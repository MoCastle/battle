using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public struct ActorDialogInfo
    {
        [Header("类型")]
        public int type;
        [Header("间隔时间")]
        public float spaceTime;
        [Header("内容")]
        public DialogLine[] linesInfo;
        public Action onDialogEnd;
        public string[] GetDialogInfo()
        {
            string[] strArr = new string[linesInfo.Length];
            for(int idx = 0;idx < linesInfo.Length;++idx)
            {
                strArr[idx] = linesInfo[idx].dialogConversation;
            }
            return strArr;
        }
    }
    [Serializable]
    public struct DialogLine
    {
        [Header("文字")]
        public string dialogConversation;
        [Header("持续时间")]
        public float continueTime;
    }
}

