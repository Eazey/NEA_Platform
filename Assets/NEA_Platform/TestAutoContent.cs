
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  TestAutoContent.cs
//  Create on 4/22/2018
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

public class TestAutoContent : MonoBehaviour {


    [SerializeField]
    private int _char = 218;

    Text _text;

	// Bind Component 
	void Awake () {
        _text = GetComponent<Text>();

    }
	
	// Init Function
	void Start () {

        _text.text = "这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是测试的话！这是...";
        Debug.Log(_text.preferredHeight);
        Debug.Log(_text.minHeight);
        Debug.Log(_text.flexibleHeight);

        string str = _text.text;
        byte[] buffers = System.Text.Encoding.Default.GetBytes(str);
        Debug.Log(buffers.Length);
    }
}
