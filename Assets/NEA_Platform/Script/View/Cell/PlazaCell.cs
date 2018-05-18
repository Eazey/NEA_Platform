
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
    private Text _like_Text;
    [SerializeField]
    private Text _collect_Text;
    [SerializeField]
    private RectTransform _cell;

    [Header("Action")]
    [SerializeField]
    private Button _like_Btn;
    [SerializeField]
    private Button _collect_Btn;

    [Header("Rect")]
    [SerializeField]
    private int _normalHeight = 264;

    // 锚点
    [SerializeField]
    private GameObject _contentAncor;
    [SerializeField]
    private GameObject _fixBtnAncor;


    private int likeNum;
    private int collectNum;

    void Awake()
    {
        //PlazaData data = new PlazaData(0, null, "asfd", "2193", "这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这" +
        //    "是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试" +
        //    "的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试" +
        //    "测试的话！这是测试"
        //    , null,
        //    10, 10);

        //InitCell(data);
    }

    // 这里根据数据类型（纯文字，图文，文章等）的不同应该重载
    // 该对象应该作为参数发给数据类 由数据类决策方法
    public override void InitCell(PlazaData data)
    {
        _icon.sprite = data.Icon;
        _theme.text = data.Theme;
        _time.text = data.Time;

        likeNum = data.Like;
        _like_Text.text = likeNum.ToString();

        collectNum = data.Collect;
        _collect_Text.text = collectNum.ToString();

        GameObject contentGo = AssetManager.LoadGameObject(AssetManager.PlazaContentPath);
        AssetManager.SetParent(contentGo, _contentAncor);
        Text contentText = contentGo.GetComponent<Text>();
        contentText.text = data.Content;

        float contentH = contentText.preferredHeight;
        if (contentH > _normalHeight)
        {
            GameObject fixBtnGo = AssetManager.LoadGameObject(AssetManager.FixTextBtnPath);
            AssetManager.SetParent(fixBtnGo, _fixBtnAncor);
            float fixY = fixBtnGo.GetComponent<RectTransform>().sizeDelta.y;
            float cellY = _cell.sizeDelta.y;
            _cell.sizeDelta = new Vector2(_cell.sizeDelta.x, fixY + cellY);

            FixTextBtn btn = fixBtnGo.GetComponent<FixTextBtn>();
            btn.RegisterEvent(() => Unfold(contentText), () => PackUp(contentText));
        }

        float cellH = contentH > _normalHeight ? _normalHeight : contentH;
        contentText.rectTransform.sizeDelta = new Vector2(contentText.rectTransform.sizeDelta.x, cellH);
        float cellY2 = _cell.sizeDelta.y;
        _cell.sizeDelta = new Vector2(_cell.sizeDelta.x, cellH + cellY2);
    }

    private void Unfold(Text contentText)
    {
        contentText.rectTransform.sizeDelta = new Vector2(contentText.rectTransform.sizeDelta.x, contentText.preferredHeight);
        float deltaH = contentText.preferredHeight - _normalHeight;
        _cell.sizeDelta = new Vector2(_cell.sizeDelta.x, _cell.sizeDelta.y + deltaH);
    }

    private void PackUp(Text contentText)
    {
        contentText.rectTransform.sizeDelta = new Vector2(contentText.rectTransform.sizeDelta.x, _normalHeight);
        float deltaH = contentText.preferredHeight - _normalHeight;
        _cell.sizeDelta = new Vector2(_cell.sizeDelta.x, _cell.sizeDelta.y - deltaH);
    }
}
