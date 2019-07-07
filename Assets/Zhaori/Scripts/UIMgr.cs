using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour {

    public static UIMgr Ins;

    private GameObject UIRoot;

    //private Dictionary<string, UIPanel> UIPanels = new Dictionary<string, UIPanel>();

    private Dictionary<string, GameObject> UIPanelGos = new Dictionary<string, GameObject>();
    
    private void Awake()
    {
        Ins = this;
    }
    float mtime;

    public T OpenPanel<T>() where T : UIPanel
    {
        string panelName = typeof(T).ToString();

        foreach (var item in UIPanelGos)
        {
           if( item.Key == panelName)
            {
                item.Value.SetActive(true);
                return item.Value.GetComponent<T>();
            }
        }
        GameObject Panel = Instantiate( Resources.Load<GameObject>(panelName),transform);

        UIPanelGos.Add(panelName, Panel);

        T panel = Panel.GetComponent<T>();
        panel.Init();

        return panel;
    }

    public void ClosePane<T>()
    {
        string panelName = typeof(T).ToString();

        foreach (var item in UIPanelGos)
        {
            if (item.Key == panelName)
            {
                item.Value.SetActive(false);
            }
        }
    }

}

public interface UIPanel
{
    void Init();
    
}
