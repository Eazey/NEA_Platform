﻿
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  GameRoot.cs
//  Create on 2/17/2018
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
using UnityEngine.EventSystems;

public class GameRoot : MonoBehaviour
{
    private const string MANAGER_NAME = "Manager";
    private const string EVENTSYSTEM_NAME = "EventSystem";

    [SerializeField] protected string CANVAS_NAME = "Canvas";

    private void Awake()
    {
        Debuger.Log(EGUIFramework.LogType.Normal, "Root!!!");

        GameObject manager = GameObject.Find(MANAGER_NAME);
        if (manager == null)
            manager = new GameObject(MANAGER_NAME);
        DontDestroyOnLoad(manager);

        InitRootCanvas();
        InitEventSystem();

        //清空上个场景的界面缓存
        ViewController.GetInstance().ClearAllView();
        //注册根节点下所有界面
        ViewController.GetInstance().RegisterAllView(ViewController.GetInstance().RootCanvas);

        gameObject.AddComponent<DataFactory>();

        //状态栏
        AndroidStatusBar.statusBarState = AndroidStatusBar.States.Hidden;
        AndroidStatusBar.statusBarState = AndroidStatusBar.States.TranslucentOverContent;
    }


    private void InitRootCanvas()
    {
        //初始化 Canvas 指定为唯一接口
        GameObject canvas = GameObject.Find(CANVAS_NAME);
        if (canvas == null)
        {
            Debug.LogWarning("None Canvas");
            string path = Utility.Path.GetCruxPath(CANVAS_NAME);
            if (AssetManager.ResourceLoadObj(path, out canvas))
                canvas.name = Utility.NormalClone(canvas.name);
            else
                Debug.LogError("Not found canvas prefab in " + path);
        }
        ViewController.GetInstance().RootCanvas = canvas.transform.Find("APP");
    }

    private void InitEventSystem()
    {
        GameObject eventSystem = GameObject.Find(EVENTSYSTEM_NAME);
        if (eventSystem == null)
        {
            Debug.LogWarning("None Event System");
            string path = Utility.Path.GetCruxPath(EVENTSYSTEM_NAME);
            if(AssetManager.ResourceLoadObj(path,out eventSystem))
            {
                eventSystem.name = Utility.NormalClone(eventSystem.name);
                eventSystem.AddComponent<BaseInput>();
            }
            else
                Debug.LogError("Not found event system in " + path);
        }
    }
}
