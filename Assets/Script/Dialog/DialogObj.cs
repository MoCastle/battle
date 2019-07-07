using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameScene;

public class DialogObj : MonoBehaviour {
    public Action<PlayerObj> enterTrigerAction;
    public Action<PlayerObj> leaveTrigerAction;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.GetMask("Playr"))
        {
            if(enterTrigerAction!=null)
            {
                enterTrigerAction(collision.transform.parent.parent.GetComponent<PlayerObj>());
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("Playr"))
        {
            if (leaveTrigerAction != null)
            {
                leaveTrigerAction(collision.transform.parent.parent.GetComponent<PlayerObj>());
            }
        }
    }
}
