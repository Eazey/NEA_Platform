
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  CalcuFont.cs
//  Create on 3/16/2018
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

public class CalcuFont : MonoBehaviour {

    Text _text;
	// Bind Component 
	void Awake () {
        _text = GetComponent<Text>();
	}
	
	// Init Function
	void Start () {

        Debug.Log(_text.preferredWidth);
        Debug.Log(_text.preferredHeight);

        _text.text = "1111";
        Debug.Log(_text.preferredHeight);

        _text.text = "11111111111111111111111111111111111111111111111111111111111111111111";
        Debug.Log(_text.preferredHeight);

        if (_text.preferredWidth > 1000)
        {
            var pos = _text.rectTransform.position;
            _text.rectTransform.sizeDelta = new Vector2(100, _text.preferredHeight);
            //_text.rectTransform.position = pos;
            Debug.Log(_text.preferredHeight);
        }
        //Debug.Log(_text.PixelAdjustPoint);
    }
}
