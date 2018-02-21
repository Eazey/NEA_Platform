
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  TestButton.cs
//  Create on 2/17/2018
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

using EUIFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {

    [SerializeField]
    private ViewBase view;

    private bool isOpen = false;

	// Bind Component 
	void Awake () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            if (!isOpen)
                view.Open();
            else
                view.Close();

            isOpen = !isOpen;
        });
	}
	
	// Init Function
	void Start () {
		
	}
}
