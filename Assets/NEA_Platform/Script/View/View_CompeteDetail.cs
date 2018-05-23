
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_CompeteDetail.cs
//  Create on 5/18/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EGUIFramework;

public class View_CompeteDetail : ViewBase {

    [SerializeField]
    private CustomButton _confirmBtn;
    [SerializeField]
    private CustomButton _cancelBtn;

	void Awake()
    {
        _cancelBtn.onClick.AddListener(() => ViewController.GetInstance().CloseView(_viewName));
    }
}


public class CompeteDataManager:NormalSingleton<CompeteDataManager>
{
    private CompeteDataManager()
    {

    }

    // 比赛的ID
    private int id;
}

public class CompeteData
{
    public string ID { private set; get; }
    public string Name { private set; get; }
    public string Content { private set; get; }
}
