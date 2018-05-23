
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_Plaza.cs
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

using UnityEngine;
using UnityEngine.UI;
using EGUIFramework;
using System.Collections;
using System.Collections.Generic;

public class View_Plaza : ViewBase
{

    [Header("Action")]
    [SerializeField]
    private TagButton _newsBtn;
    [SerializeField]
    private TagButton _focusBtn;

    [Header("UI")]
    [SerializeField]
    private ScrollRect _newScroll;
    [SerializeField]
    private ScrollRect _focusScroll;
    [SerializeField]
    private Transform _newContent;
    [SerializeField]
    private Transform _focusContent;


    private Transform _content;

    private TagBtnStateManager _btnStatus;

    void Awake()
    {
        // 初始化时先加载一次最新数据
        RequestNewData();

        _content = _newContent;

        _newsBtn.Init(
            () =>
            {
                _focusScroll.transform.gameObject.SetActive(false);
                _content = _newContent;
                _newScroll.transform.gameObject.SetActive(true);
            },
            RequestNewData
        );
        _focusBtn.Init(
            () =>
            {
                _newScroll.transform.gameObject.SetActive(false);
                _content = _focusContent;
                _focusScroll.transform.gameObject.SetActive(true);
            },
            RequestFocusData
        );

        _btnStatus = new TagBtnStateManager();
        _newsBtn.StatusHandler += _btnStatus.UpdateCache;
        _focusBtn.StatusHandler += _btnStatus.UpdateCache;

        _newsBtn.Response();
    }

    protected override void Init()
    {
        transform.SetSiblingIndex(0);
    }

    private void RequestNewData()
    {
        PlazaDataManager.GetInstance().RequestData(ShowData);
    }

    private void RequestFocusData()
    {

    }

    private void ShowData(bool isSuccess, List<PlazaData> datas)
    {

        // 不成功 显示个显示错误的界面
        if (!isSuccess)
        {
            Debuger.Log(EGUIFramework.LogType.Error, "Network Error!");
            //GameObject go = AssetManager.LoadGameObject(AssetManager.ErrorPanelPath);
            //go.transform.SetParent(_content.transform);
            //go.transform.localPosition = Vector3.zero;
            //go.transform.localRotation = Quaternion.identity;
            //go.transform.localScale = Vector3.one;
            //go.transform.SetSiblingIndex(0);
            return;
        }
        //Debuger.Log(EGUIFramework.LogType.Error, "NEtwork Success!");

        foreach (var data in datas)
        {
            var temp = data;
            GameObject go;
            if (temp.Textures == null)
                go = AssetManager.LoadGameObject(AssetManager.NormalCellPath);
            else
                go = AssetManager.LoadGameObject(AssetManager.TextureCellPath);

            go.transform.SetParent(_content.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            go.transform.SetSiblingIndex(0);

            ViewCell cell = go.GetComponent<ViewCell>();
            cell.InitCell(temp);// 还有两个按钮的点击事件           
        }
    }
}
