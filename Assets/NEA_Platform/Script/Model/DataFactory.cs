
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  DataFactory.cs
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

public delegate void Test(PlazaShort data);

public enum DataType
{
    Plaza,
    Compete,
    Job,
}


public class DataFactory : MonoSingleton<DataFactory>
{

    const string PLAZA_PATH = "plaza";
    const string COMPETE_PATH = "datas/compete";
    const string JOB_PAHT = "datas/job";


    Action<bool, string> _callback;

    public void RequestData(DataType type, Action<bool, string> callback)
    {
        _callback = callback;

        switch (type)
        {
            case DataType.Plaza:
                StartCoroutine(RequestServer.DownLoad(PLAZA_PATH, ReceiveData));
                break;

            case DataType.Compete:
                StartCoroutine(RequestServer.DownLoad(COMPETE_PATH, ReceiveData));
                break;

            case DataType.Job:
                StartCoroutine(RequestServer.DownLoad(JOB_PAHT, ReceiveData));
                break;
        }
    }

    private void ReceiveData(bool isSuccess, WWW data)
    {
        if (!isSuccess)
        {
            _callback(isSuccess, null);
        }
        else
        {
            string content = data.text;
            _callback(isSuccess, content);
        }
    }

    public void RequestImageData(int id, string path, Action<int, Sprite> final)
    {
        StartCoroutine(RequestServer.GetImage(id, path, final, ReceiveImageData));
    }

    private void ReceiveImageData(int id, WWW imageData, Action<int, Sprite> final)
    {
        if (imageData.text == "none")
        {
            
            final(id, null);
            return;
        }

        Texture2D tex = imageData.texture;
        Sprite sprite = null;
        if (tex != null)
            sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        final(id, sprite);
    }
}
