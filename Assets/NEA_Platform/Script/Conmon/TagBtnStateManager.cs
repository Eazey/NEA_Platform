
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  TagButtonStateManager.cs
//  Create on 4/8/2018
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

public class TagBtnStateManager
{
    private TagButton _curBtn;

    /// <summary>
    /// 
    /// 更新缓存  
    /// 
    /// 并返回缓存是否被更新
    /// 
    /// </summary>
    /// <param name="btn"> 新的标签按钮对象 </param>
    /// <returns> 是否被更新 </returns>
    public void UpdateCache(TagButton btn)
    {

        bool isUpdate = !(btn.Equals(_curBtn));

        if (isUpdate || _curBtn == null)
        {
            if (_curBtn != null)
                _curBtn.Reset();

            _curBtn = btn;
            _curBtn.SelectStatus();
        }
        else
            _curBtn.RefreshStatus();
    }

    public void Response()
    {
        _curBtn.Response();
    }
}
