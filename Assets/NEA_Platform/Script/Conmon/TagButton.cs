
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  TagButton.cs
//  Create on 3/23/2018
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

public class TagButton : CustomButton {

    [SerializeField]
    private Text _nameTex;

    bool isSelect = false;

    UnityAction unSelectAction;
    UnityAction selectAction;

    void Awake()
    {
        onClick.AddListener(OnTagClick);
    }

    public void EnableBtn()
    {
        OnTagClick();
    }

    private void OnTagClick()
    {
        if (isSelect)
        {
            selectAction();
        }
        else
        {
            unSelectAction();
            TagButtonStatus.GetInstance().Cache(this);
            SelectShow(true);
        }
    }


    public void Init(UnityAction unSelect, UnityAction select)
    {
        unSelectAction = unSelect;
        select = selectAction;
    }

    public void Reset()
    {
        isSelect = false;
        SelectShow(false);
    }

    public void Animation(float value)
    {

    }

    public void SelectShow(bool isShow)
    {
        if (isShow)
            _nameTex.color = Color.red;
        else
            _nameTex.color = Color.black;
    }
}

public class TagButtonStatus : NormalSingleton<TagButtonStatus>
{
    private TagButtonStatus() { }

    private TagButton _curBtn;

    public void Cache(TagButton btn)
    {
        if (_curBtn != null)
            _curBtn.Reset();

        _curBtn = btn;
    }

}
