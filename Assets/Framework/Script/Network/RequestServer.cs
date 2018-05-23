
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

public delegate void TryConctServerDelegate(bool isSuccess, WWW www);
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


        public static IEnumerator DownLoad(string path, Action<bool,WWW> callback)
        {
            string url = _ip + "/get?download=" + path;
            Debug.Log(url);
            WWW www = new WWW(url);
            yield return www;

            if(callback!=null)
            {
                if (!CheckError(www.error))
                    callback(true, www);
                else
                    callback(false, null);
            }              
        }


        public static IEnumerator Upload(string path, WWWForm form, Action<bool, WWW> callback = null)
        {
            string url = _ip + path;

            WWW www = new WWW(url, form);
            yield return www;

            if (callback != null)
            {
                if (!CheckError(www.error))
                    callback(true, www);
                else
                    callback(false, null);
            }
        }

        public static IEnumerator GetImage(int id,string path, Action<int, Sprite> final, Action<int,WWW, Action<int, Sprite>> middle)
        {

            string url = "http://127.0.0.1:8888/get/image?imagePath=" + path;

            WWW www = new WWW(url);
            yield return www;

            middle(id, www, final);                
        }
    }
}
