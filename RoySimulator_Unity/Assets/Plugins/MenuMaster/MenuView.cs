using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{

    public RectTransform rt;
    public string ViewName { get{ return name.ToLower().Replace("menu","").Replace("view", ""); } }

    protected Button[] buttons;

    protected virtual void Awake()
    {
        rt = GetComponent<RectTransform>();
        buttons = GetComponentsInChildren<Button>();
        gameObject.SetActive(false);
    }

    protected void OnEnable()
    {       
        if (buttons != null && buttons.Length != 0)
        { 
            //select first button 
            buttons[0].Select();
            buttons[0].OnSelect(null);
        }
    }

    /// <summary>
    /// Get rect transform when key matches
    /// </summary>
    /// <param name="viewName">name of view</param>
    /// <param name="_rt"></param>
    /// <returns></returns>
    public bool GetTransformWhenMathing(string viewName, out RectTransform _rt)
    {
        _rt = rt;
        return ViewName.Contains(viewName);
    }


}