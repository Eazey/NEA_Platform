
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  AssetManager.cs
//  Create on 2/20/2018
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
using EUIFramework;

public class AssetManager
{
    public static bool ResourceLoad<TOut>(string path, out TOut asset)
        where TOut : UnityEngine.Object
    {
        bool result = false;
        asset = Resources.Load<TOut>(path);
        if (asset != null)
            result =  true;
        return result;
    }

    public static bool ResourceLoadObj(string path, out GameObject go, Transform parent = null)
    {
        bool result = false;
        go = null;

        GameObject prefab;
        if (ResourceLoad<GameObject>(path, out prefab))
        {
            if (parent != null)
                go = GameObject.Instantiate(prefab, parent);
            else
                go = GameObject.Instantiate(prefab);

            Resources.UnloadAsset(prefab);
        }
        return result;
    }
}
