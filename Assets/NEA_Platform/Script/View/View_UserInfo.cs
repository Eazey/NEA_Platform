
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  View_UserInfo.cs
//  Create on 5/23/2018
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

public class View_UserInfo : MonoBehaviour {

    public Button _lol;
    public Button _pubg;
    public Button _ow;
    public Button _dota2;

    public InputField _un;
    public InputField _email;
    public InputField _phone;

    private List<string> _themeStr;

    public GameObject _tip;

    [Header("Control")]
    public Button _confirm;
    public Button _cancel;

	// Bind Component 
	void Awake () {

        _themeStr = new List<string>();
        _tip.SetActive(false);

        _lol.onClick.AddListener(() => ClickChange(_lol));
        _pubg.onClick.AddListener(() => ClickChange(_pubg));
        _ow.onClick.AddListener(() => ClickChange(_ow));
        _dota2.onClick.AddListener(() => ClickChange(_dota2));

        _confirm.onClick.AddListener(ConfirmBTn);
        _cancel.onClick.AddListener(CancelBtn);
    }
	
	// Init Function
	void Start () {
		
	}

    private void ClickChange(Button btn)
    {
        Text text = btn.GetComponentInChildren<Text>();
        Image bg = btn.transform.Find("bg").GetComponent<Image>();
        
        if(bg.gameObject.activeSelf == false)
        {
            bg.gameObject.SetActive(true);
            text.color = Color.white;
            _themeStr.Add(text.text);
        }
        else
        {
            bg.gameObject.SetActive(false);
            text.color = Color.black;
            _themeStr.Remove(text.text);
        }
    }

    private void ConfirmBTn()
    {
        if(string.IsNullOrEmpty(_un.text)
            || string.IsNullOrEmpty(_email.text)
            || string.IsNullOrEmpty(_phone.text))
        {
            _tip.SetActive(true);
            StartCoroutine(TipDis());
        }
    }

    private void CancelBtn()
    {

    }

    IEnumerator TipDis()
    {
        yield return new WaitForSeconds(1);
        _tip.SetActive(false);
    }
}
