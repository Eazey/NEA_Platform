 
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  MonoSingleton.cs
//  Create on 2/16/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 基于 MonoBehaviour 类的单例模板基类
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EUIFramework
{
    public class MonoSingleton<T> : MonoBehaviour
        where T : MonoSingleton<T>
    {
        private const string GAME_MANAGER = "Manager";

        private static T _instance = null;

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject manager = GameObject.Find(GAME_MANAGER);
                    if (manager == null)
                    {
                        Debug.LogError("Please check the pbject named 'Root' whether be created.");
                        manager = new GameObject(GAME_MANAGER);
                        DontDestroyOnLoad(manager);
                    }
                    _instance = manager.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}