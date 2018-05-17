
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

public class DataFactory : NormalSingleton<DataFactory>
{

    const string PLAZA_PATH = "datas/plaza";
    const string COMPETE_PATH = "datas/compete";
    const string JOB_PAHT = "datas/job";

    private DataFactory() { }


    ReqServerDelegate _callback;

    public void RequestData(DataType type, ReqServerDelegate callback)
    {
        _callback = callback;

        switch (type)
        {
            case DataType.Plaza:
                RequestServer.DownLoad(PLAZA_PATH, ReceiveData);
                break;

            case DataType.Compete:
                RequestServer.DownLoad(COMPETE_PATH, ReceiveData);
                break;

            case DataType.Job:
                RequestServer.DownLoad(JOB_PAHT, ReceiveData);
                break;
        }
    }

    public void ReceiveData(WWW data)
    {
        
    }
}
