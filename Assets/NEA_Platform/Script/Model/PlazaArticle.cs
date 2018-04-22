
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaArticle.cs
//  Create on 4/9/2018
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

public class PlazaArticle: PlazaBaseData {

    public string Title { get; set; }

    public PlazaArticle(Sprite icon, string theme, string time,
        string title, string author, string content)
        : base(icon, theme, time, author, content)
    {
        Title = title;
    }

    public override void ShowCell(ref ViewCell cell)
    {
        
    }

    public override void ShowView(ref ViewBase view)
    {
        
    }
}
