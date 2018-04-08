
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaCell.cs
//  Create on 4/8/2018
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

public class PlazaCell : ViewCell {

    [Header("UI")]
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Text _theme;
    [SerializeField]
    private Text _time;
    [SerializeField]
    private Text _content;

    [Header("Rect")]
    [SerializeField]
    private float _normalHeight;


    // 这里根据数据类型（纯文字，图文，文章等）的不同应该重载
    // 该对象应该作为参数发给数据类 由数据类决策方法

    public void InitCell(Sprite icon, string theme, string time,
        string content)
    {
        _icon.sprite = icon;
        _theme.text = theme;
        _time.text = time;
        _content.text = content;
    }
}
