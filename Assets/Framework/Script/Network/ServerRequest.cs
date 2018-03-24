
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  ViewController.cs
//  Create on 3/24/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 控制所有的界面
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;
using EGUIFramework;

/*
    public string url = "http://118.89.222.41:8888/";
    public string postUrl = "http://118.89.222.41:8888/add/";
    public string urlWithParam = "http://118.89.222.41:8888/add?name=jt";
    public string imageUrl = "http://118.89.222.41:8888/images/todo-usecase.png";
*/

public enum ReceiveMessageType
{
    /// <summary>
    /// Error messages generated before the server connection.
    /// </summary>
    Unconnected,
    /// <summary>
    /// Error messages generated after the server connection.
    /// </summary>
    Unchecked,
}

public enum FileType
{
    CSV,
    JSON,
    XML,
    TXT,
    JPG,
}


public class ServerRequest : NormalSingleton<ServerRequest> {

    private ServerRequest()
    {

    }

    public static string GetFileExtension(FileType fileType)
    {
        string result = string.Empty;
        switch (fileType)
        {
            case FileType.CSV: result = ".csv"; break;
            case FileType.JSON: result = ".json"; break;
            case FileType.JPG: result = ".jpg"; break;
        }

        return result;
    }

    public IEnumerator GetData(string fileName, string filePath, FileType fileType)
    {
        string extension = GetFileExtension(fileType);

        WWWForm form = new WWWForm();
        form.AddField(PARAMS_TYPE, "main_plaza");
        form.AddField("fileName", fileName);
        form.AddField("filePath", filePath);
        form.AddField("fileType", extension);

        WWW www = new WWW("http://127.0.0.1:8888/download/", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            string message = www.text;
            Debug.Log("ServerRequesr receive message: " + message);
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

    // field name
    const string PARAMS_TYPE = "params_type";
    const string ACCOUNT_NUMBER = "account_number";
    const string ACCOUNT_PASSWORD = "account_password";

    //PARAMS_TYPE value
    const string ACCOUNT_NUMBER_ONLY = "account_number_only";
    const string ACCOUNT_REGISTER = "account_register";
    const string ACCOUNT_LOGIN = "account_login";

    //The field "_url" is baned.
    private static string _url = "";
    /// <summary>
    /// Gain the server url from XML. (Only way)
    /// </summary>
    public static string URL
    {  
        get
        {   
            //if (string.IsNullOrEmpty(_url))
            //{
            //    Debug.Log("Read url from XML.");               
            //    XmlDocument xmldoc = new XmlDocument();
            //    string content = Resources.Load(ApplicationExtend.configPath).ToString();
            //    xmldoc.LoadXml(content);
            //    XmlNode rootNode = xmldoc.SelectSingleNode("root");
            //    XmlNode urlNode = rootNode.FirstChild;
            //    _url = urlNode.InnerText;

            //}
            return _url;
        }
    }
    
    void OnEnable()
    {
        Init();
    }

    void Init()
    {       
        Debug.Log("Class ServerRequest:_url =" + URL);
    }

    private void ReceiveCheck(WWW www, CheckMessageDelegate callback)
    {
        if (string.IsNullOrEmpty(www.error))
        {
            string message = www.text;
            Debug.Log("ServerRequesr receive message: " + message);
            //if success, the message is empty, or else show the details.
            callback(string.IsNullOrEmpty(message), message);
        }
        else
        {
            Debug.Log(www.error);
            callback(string.IsNullOrEmpty(www.error), "Request Failure!");
        }
    }

    /// <summary>
    /// Just made the function on register.
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator SendAccountNumber(string accountNumber, CheckMessageDelegate callback)
    {
        Debug.Log("ServerRequest - SendAccountNumber");

        WWWForm form = new WWWForm();
        form.AddField(PARAMS_TYPE, ACCOUNT_NUMBER_ONLY);
        form.AddField(ACCOUNT_NUMBER, accountNumber);

        WWW www = new WWW(URL, form);
        yield return www;

        ReceiveCheck(www, callback);

        //StopCoroutine(SendAccountNumber(accountNumber, callback));
    }

    /// <summary>
    /// Register function, send account number and password to server.
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="password"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator SendRegister(string accountNumber, string password, CheckMessageDelegate callback)
    {
        Debug.Log("ServerRequest - Send Register");

        WWWForm form = new WWWForm();
        form.AddField(PARAMS_TYPE, ACCOUNT_REGISTER);
        form.AddField(ACCOUNT_NUMBER, accountNumber);
        form.AddField(ACCOUNT_PASSWORD, password);

        WWW www = new WWW(URL, form);
        yield return www;

        ReceiveCheck(www, callback);

        //StopCoroutine(SendRegister(accountNumber, password, callback));
    }

    /// <summary>
    /// Login function, send account number and password to server.
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="password"></param>
    /// <param name="callback"></param>
    /// <returns></returns>
    public IEnumerator SendLogin(string accountNumber, string password, CheckMessageDelegate callback)
    {
        Debug.Log("ServerRequest - Send Login");

        WWWForm form = new WWWForm();
        form.AddField(PARAMS_TYPE, ACCOUNT_LOGIN);
        form.AddField(ACCOUNT_NUMBER, accountNumber);
        form.AddField(ACCOUNT_PASSWORD, password);

        WWW www = new WWW(URL, form);
        yield return www;

        ReceiveCheck(www, callback);

        //StopCoroutine(SendLogin(accountNumber, password, callback));
    }
}

public delegate void CheckMessageDelegate(bool isTrue, string message);
