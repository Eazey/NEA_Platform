
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

namespace EGUIFramework
{
    public class ViewBase : MonoBehaviour, IView
    {
        [SerializeField]
        protected ViewName _viewName;
        public ViewName Name { get { return _viewName; } }

        [Header("Component")]
        [SerializeField]
        protected ViewContent _viewContent;

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


        protected virtual void Init()
        {

        }

        protected virtual void Clear()
        {

        }
    }
}