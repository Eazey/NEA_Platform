
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  Debuger.cs
//  Create on 4/29/2018
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


namespace EGUIFramework
{
    public enum LogType
    {
        Normal,
        Warnning,
        Error,
    }
    public static class Debuger
    {
        public static bool isEnable = true;

        public static void Log(LogType type, string msg)
        {
            if (!isEnable)
                return;

            switch (type)
            {
                case LogType.Normal: Debug.Log(msg); break;
                case LogType.Warnning: Debug.LogWarning(msg); break;
                case LogType.Error: Debug.LogError(msg); break;
            }
        }
        public static void CheckNullObj(object obj, string msg)
        {
            if (!isEnable)
                return;

            if (obj == null)
                throw new Exception(msg);
        }
    }
}


