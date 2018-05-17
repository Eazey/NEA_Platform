
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaData.cs
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


public enum PlazaDataType
{
    ShortMessage,
    Article,

}

public abstract class PlazaBaseData {

    public Sprite Icon { get; set; }
    public string Theme { get; set; }
    public string Time { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    public PlazaBaseData(Sprite icon, string theme,
        string time, string author,string content)
    {
        Icon = icon;
        Theme = theme;
        Time = time;
        Author = author;
        Content = content;
    }

    public abstract void ShowCell(ref ViewCell cell);

    public abstract void ShowView(ref ViewBase view);
}
