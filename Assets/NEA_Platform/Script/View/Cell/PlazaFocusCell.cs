
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaFocusCell.cs
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

public class PlazaFocusCell : ViewCell {


    [Header("UI")]
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Text _theme;
    [SerializeField]
    private Text _time;
    [SerializeField]
    private Text _content;
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _like_Text;
    [SerializeField]
    private Text _collect_Text;

    [Header("Action")]
    [SerializeField]
    private Button _like_Btn;
    [SerializeField]
    private Button _collect_Btn;

    private int likeNum;
    private int collectNum;

    public override void InitCell(PlazaData data)
    {
        _icon.sprite = data.Icon;
        _theme.text = data.Theme;
        _time.text = data.Time;

        likeNum = data.Like;
        _like_Text.text = likeNum.ToString();

        collectNum = data.Collect;
        _collect_Text.text = collectNum.ToString();

        _image.sprite = data.Textures;
        _content.text = data.Content;

        float contentH = _content.preferredHeight;
        _content.rectTransform.sizeDelta = new Vector2(_content.rectTransform.sizeDelta.x, contentH);
    }
}
