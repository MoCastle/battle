using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class test : MonoBehaviour {
    public Image img;
    private void Update()
    {
        Text text = GetComponent<Text>();
        CharacterInfo info = new CharacterInfo();
        text.font.GetCharacterInfo('f', out info, 14);//14是字体的字号，可以从text里获取。
        RectTransform rectTransform = img.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(info.advance, 1);
        Debug.Log(info.advance);
        //RectTransform rectTransform = img.GetComponent<RectTransform>();
        //rectTransform.sizeDelta = new Vector2(text.preferredWidth,1 ) ;

    }
	
}
