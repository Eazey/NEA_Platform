
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  ControlBtn.cs
//  Create on 5/22/2018
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

public class ControlBtn : CustomButton {

    [SerializeField]
    private Sprite _selectSpr;
    [SerializeField]
    private Sprite _normalSpr;
    [SerializeField]
    private Image _btnImage;


	public void Select()
    {
        _btnImage.sprite = _selectSpr;
    }

    public void Reset()
    {
        _btnImage.sprite = _normalSpr;
    }
}
