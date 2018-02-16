
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


public class View_Base : MonoBehaviour, IView
{

    public void Open()
    {
        gameObject.SetActive(true);
        OpenView();
    }

    public void Close()
    {
        CloseView();
        gameObject.SetActive(false);
    }

    public void Transer(ViewName viewName)
    {

    }

    protected virtual void OpenView()
    {

    }

    protected virtual void CloseView()
    {

    }
}
