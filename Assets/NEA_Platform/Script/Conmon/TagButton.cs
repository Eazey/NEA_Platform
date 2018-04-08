
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

    [Header("Color")]
    [SerializeField]
    private Color _normalColor;
    [SerializeField]
    private Color _highColor;

    bool isSelect = false;

    //UnityAction unSelectAction;
    //UnityAction selectAction;

    UnityAction selectAction;
    UnityAction refreshAction;

    public TagBtnStatusDelegate StatusHandler;


    void Awake()
    {
        onClick.AddListener(OnTagBtnClick);
    }

    public void Response()
    {
        OnTagBtnClick();
    }

    private void OnTagBtnClick()
    {
        if (StatusHandler == null)
            throw new Exception("StatusHandler 未被指定");

        StatusHandler(this);
    }

    public void SelectStatus()
    {
        if (selectAction != null)
            selectAction();

        SelectShow(true);

        Debug.Log("I'm select! " + name);
    }

    public void RefreshStatus()
    {
        if (refreshAction != null)
            refreshAction();

        Debug.Log("I'm freash! " + name);
    }


    public void Init(UnityAction select, UnityAction refresh)
    {
        select = selectAction;
        refresh = refreshAction;
    }

    public void Reset()
    {
        isSelect = false;
        SelectShow(false);
    }


    public void SelectShow(bool isHigh)
    {
        Debug.Log("Button：" + name + ". 高亮状态：" + isHigh);

        Color orgin = isHigh ? _normalColor : _highColor;
        Color end = isHigh ? _highColor : _normalColor;

        _colorChange = ChangeColor(orgin, end);
        StartCoroutine(_colorChange);
    }

    IEnumerator _colorChange;

    IEnumerator ChangeColor(Color orgin, Color end)
    {
        for(int i = 0; i < 20; i++)
        {
            _nameTex.color = Color.Lerp(orgin, end, i * 0.1f);
            yield return new WaitForEndOfFrame();
        }

        StopCoroutine(_colorChange);
        _colorChange = null;
    }

    public override bool Equals(object other)
    {
        if (other == null)
            return false;

        var otherBtn = (TagButton)other;
        return name == otherBtn.name;
    }
}

public delegate void TagBtnStatusDelegate(TagButton btn);

