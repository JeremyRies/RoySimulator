using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;


public class PopUpView : MenuView
{
    
    private Text titleLabel;
    private Text subtitleLabel;
    private List<Text> buttonLabels;


    protected override void Awake()
    {
        buttonLabels = new List<Text>();
        titleLabel = transform.GetChild(0).GetComponent<Text>();
        subtitleLabel = transform.GetChild(1).GetComponent<Text>();

        base.Awake();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonLabels.Add(buttons[i].GetComponent<Text>());
        }

    }

    public void SetOptions(string title,string subtitle,string option1,string option2,Action Callbackoption1, Action Callbackoption2)
    {
        titleLabel.text = title;
        subtitleLabel.text = subtitle;
       
        buttonLabels[0].text = option1;
        buttons[0].onClick.RemoveAllListeners();
        buttons[0].onClick.AddListener(() => Callbackoption1());

        buttons[1].onClick.RemoveAllListeners();
        buttonLabels[1].text = option2;
        buttons[1].onClick.AddListener(() => Callbackoption2());
    }
}
