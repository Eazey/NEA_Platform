
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  Utility.cs
//  Create on 2/19/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 通用功能类
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EUIFramework
{
    public static class Utility
    {
        public static class Path
        {
            public static string ViewRoot { get { return "View/"; } }
            public static string CruxRoot { get { return "Crux/"; } }

            public static string GetViewPath(string viewName)
            {
                return ConnectPath(ViewRoot, viewName);
            }

            public static string GetCruxPath(string curxName)
            {
                return ConnectPath(CruxRoot, curxName);
            }

            public static string ConnectPath(string root, string subset)
            {
                string path = root + '/' + subset;
                return path;
            }
        }


        public static class View
        {
            public static GameObject InitUIObj(GameObject go)
            {
                RectTransform rect = go.GetComponent<RectTransform>();
                if (rect != null)
                {
                    rect.anchoredPosition = Vector3.zero;
                    rect.localRotation = Quaternion.identity;
                    rect.localScale = Vector3.one;
                    //rect.offsetMin = 0.5f * Vector2.one;
                    //rect.offsetMax = 0.5f * Vector2.one;
                }
                go.layer = go.transform.parent.gameObject.layer;
                go.name = NormalClone(go.name);

                return go;
            }
        }

        public static string NormalClone(string name)
        {
            if (name.Contains("(Clone)"))
                name = name.Replace("(Clone)", "").Trim();
            return name;
        }
    }
}


