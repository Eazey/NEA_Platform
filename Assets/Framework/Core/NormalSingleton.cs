
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  NormalSingleton.cs
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
 * 普通类的单例模板基类
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using UnityEngine;
using System.Reflection;

public class NormalSingleton<T>
    where T : NormalSingleton<T>
{
    private NormalSingleton() { }

    private static T _instance = null;

    public static T GetInstance()
    {
        if(_instance == null)
        {
            ConstructorInfo[] constructors = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            ConstructorInfo targetMethod = Array.Find(constructors, e => e.GetParameters().Length == 0);
            if (targetMethod == null)
                Debug.LogError("Please check '" + typeof(T).ToString() + "' whether exist private constructor.");
            _instance = (T)targetMethod.Invoke(null);
        }
        return _instance;
    }
}
