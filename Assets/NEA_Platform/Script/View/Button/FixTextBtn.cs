
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  FixTextBtn.cs
//  Create on 4/18/2018
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
using UnityEngine.Events;

public class FixTextBtn : CustomButton {


    [SerializeField]
    private Text _nameText;


    private bool isUnfold = false;

    private UnityAction _unfoldAct; //展开
    private UnityAction _packupAct; //收起


	public void RegisterEvent(UnityAction unfold, UnityAction packup)
    {
        _unfoldAct = unfold;
        _packupAct = packup;

        onClick.AddListener(ClickEvent);
    }

    private void ClickEvent()
    {
        if (_unfoldAct == null || _packupAct == null)
            throw new Exception("FixTextBtn is undefined.");

        if(!isUnfold)
        {
            _unfoldAct();
            _nameText.text = "收起";
        }
        else
        {
            _packupAct();
            _nameText.text = "全文";
        }

        isUnfold = !isUnfold;
    }

    void OnDestroy()
    {
        _unfoldAct = null;
        _packupAct = null;
    }
}
