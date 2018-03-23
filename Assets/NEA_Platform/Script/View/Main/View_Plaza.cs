
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

public class View_Plaza : ViewBase {

    [SerializeField]
    private TagButton _newsBtn;
    [SerializeField]
    private TagButton _focusBtn;


    // data
    

    private void FirstNews()
    {
        // if data == null
        // refreash


    }

    private void SecondNews()
    {
        // refreash
    }

    private void FirstFocus()
    {
        // if data == null
        // refreash


    }

    private void SecondFocus()
    {
        // refreash
    }

    void Awake()
    {
        //_newsBtn.Init()

        FirstLoad();
    }
    
    private void FirstLoad()
    {
        _newsBtn.EnableBtn();
    }
}
