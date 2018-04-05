
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_Plaza.cs
//  Create on 3/23/2018
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

using UnityEngine;
using UnityEngine.UI;
using EGUIFramework;
using System.Collections;

public class View_Plaza : ViewMain {

    [Header("Action")]
    [SerializeField]
    private TagButton _newsBtn;
    [SerializeField]
    private TagButton _focusBtn;

    private TagBtnStateManager _btnStatus;

    void Awake()
    {
        _btnStatus = new TagBtnStateManager();
        _newsBtn.StatusHandler += _btnStatus.UpdateCache;
        _focusBtn.StatusHandler += _btnStatus.UpdateCache;

        _newsBtn.Response();
    }

}
