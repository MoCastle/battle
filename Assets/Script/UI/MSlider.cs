using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameScene;
using UnityEngine.UI;
public class MSlider : MonoBehaviour {
    Slider m_slider;
    public GameObject m_SliderPicture;
    public BaseActorObj m_Actor;

	// Use this for initialization
	void Start () {
        m_slider = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        SetValue(m_Actor.m_ActorPropty.percentLife);
	}

    void SetValue(float value)
    {
        if(value<0.1)
        {
            gameObject.active = false;
        }else
        {
            gameObject.active = true;
        }
        m_slider.value = value;
    }
}
