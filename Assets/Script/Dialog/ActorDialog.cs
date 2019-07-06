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

