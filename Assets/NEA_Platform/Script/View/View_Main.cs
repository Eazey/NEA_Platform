
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_Main.cs
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

public class View_Main : ViewBase {

    [Header("Action")]
    [SerializeField]
    private ControlBtn _plazaBtn;
    [SerializeField]
    private ControlBtn _competeBtn;
    [SerializeField]
    private ControlBtn _jobBtn;
    [SerializeField]
    private ControlBtn _userBtn;


    private ControlBtn _curCtrlBtn;

     

    void Awake()
    {
        _plazaBtn.onClick.AddListener(() =>
        {
            ViewController.GetInstance().OpenView(ViewName.View_Plaza, this.transform);
            _plazaBtn.Select();
            if (_curCtrlBtn != null)
                _curCtrlBtn.Reset();
        });

        _competeBtn.onClick.AddListener(() =>
        {
            ViewController.GetInstance().OpenView(ViewName.View_Compete, this.transform);
            _competeBtn.Select();
            if (_curCtrlBtn != null)
                _curCtrlBtn.Reset();
        });

        _jobBtn.onClick.AddListener(() =>
        {
            ViewController.GetInstance().OpenView(ViewName.View_Job, this.transform);
            _jobBtn.Select();
            if (_curCtrlBtn != null)
                _curCtrlBtn.Reset();
        });

        _userBtn.onClick.AddListener(() =>
        {
            ViewController.GetInstance().OpenView(ViewName.View_Me, this.transform);
            _userBtn.Select();
            if (_curCtrlBtn != null)
                _curCtrlBtn.Reset();
        });

        _plazaBtn.onClick.Invoke();

    }

    protected override void Init()
    {
        base.Init();
    }

    
}
