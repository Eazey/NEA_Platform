
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  RequestServer.cs
//  Create on 4/7/2018
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
using System.Text;

public delegate void ReqServerDelegate(WWW www);

namespace EGUIFramework
{
    public static class RequestServer
    {
        static readonly string _ip;

        static RequestServer()
        {
            string path = "Config/IP";
            var ipFile = Resources.Load<TextAsset>(path);
            if (ipFile == null)
                throw new Exception(path + "文件未能加载 " + " 目标：ip地址");
            _ip = ipFile.text;
            Debuger.Log(LogType.Normal, _ip);
        }


        private static bool CheckError(string error)
        {
            bool isError = !string.IsNullOrEmpty(error);
            if (!string.IsNullOrEmpty(error))
                Debuger.Log(LogType.Error, error);

            return isError;
        }


        public static IEnumerator DownLoad(string path, ReqServerDelegate callback)
        {
            string url = _ip + path;

            WWW www = new WWW(url);
            yield return www;

            if (!CheckError(www.error) && callback != null)
                callback(www);                
        }


        public static IEnumerator Upload(string path, WWWForm form, ReqServerDelegate callback = null)
        {
            string url = _ip + path;

            WWW www = new WWW(url, form);
            yield return www;

            if (!CheckError(www.error) && callback != null)
                callback(www);
        }
    }
}
