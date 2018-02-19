
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_Base.cs
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
 * 界面基类
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EUIFramework
{
    public class View_Base : MonoBehaviour, IView
    {
        [SerializeField]
        protected ViewName _viewName;
        public ViewName Name { get { return _viewName; } }

        public void Open()
        {
            gameObject.SetActive(true);
            Init();
        }

        public void Close()
        {
            Clear();
            gameObject.SetActive(false);
        }

        protected void Transer(ViewName viewName)
        {
            Close();
            ViewController.OpenView(viewName);
        }

        protected virtual void Init()
        {

        }

        protected virtual void Clear()
        {

        }
    }
}