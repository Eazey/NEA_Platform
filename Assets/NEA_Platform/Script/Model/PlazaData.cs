
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaData.cs
//  Create on 5/17/2018
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

public class PlazaData
{
    public int ID { private set; get; }
    public Sprite Icon { private set; get; }
    public string Theme { private set; get; }
    public string Time { private set; get; }
    public string Content { private set; get; }
    public Sprite Textures { private set; get; }
    public int Collect { private set; get; }
    public int Like { private set; get; }


    public PlazaData(int id, Sprite icon, string theme, string time,
        string content, Sprite textures, int like, int collect)
    {
        ID = id;
        Icon = icon;
        Theme = theme;
        Time = time;
        Content = content;
        Textures = textures;
        like = Like;
        Collect = collect;
    }
}
