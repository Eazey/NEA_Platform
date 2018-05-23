
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  PlazaDataManager.cs
//  Create on 5/17/2018
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
using UnityEngine.Events;

public class PlazaDataManager : NormalSingleton<PlazaDataManager>
{
    // 记录当前客户端最新的数据编号
    private int dataIndex;


    private const string ID = "ID";
    private const string ICON = "Icon";
    private const string THEME = "Theme";
    private const string TIME = "Time";
    private const string CONTENT = "Content";
    private const string TEXTURE = "Texture";
    private const string COLLECT = "Collect";
    private const string LIKE = "Like";


    List<Dictionary<string, string>> maps;
    List<PlazaData> datas;
    Dictionary<int, Sprite> dataSprite;

    Action<bool, List<PlazaData>> _uiDataCB;

    private PlazaDataManager()
    {
        maps = new List<Dictionary<string, string>>();
        datas = new List<PlazaData>();
        dataSprite = new Dictionary<int, Sprite>();
    }

    public void RequestData(Action<bool, List<PlazaData>> callback)
    {
        _uiDataCB = callback;
        DataFactory.GetInstance().RequestData(DataType.Plaza, ReceiveData);
    }

    /// <summary>
    /// 格式：
    /// Theme:LOL,Time:2018/02/01|Theme:LOL,Time:2018/02/01
    /// </summary>
    /// <param name="content"></param>
    private void ReceiveData(bool isSuccess, string dataStr)
    {
        if(!isSuccess)
        {
            _uiDataCB(false, null);
            return;
        }

        string[] dataBlock = dataStr.Split('\n');
        for (int i = 0; i < dataBlock.Length - 1; i++)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            var block = dataBlock[i];
            string[] lines = block.Split(',');
            for (int j = 0; j < lines.Length; j++)
            {
                string[] pair = lines[j].Split(':');
                string key = pair[0];
                string value = pair[1];

                map.Add(key, value);
            }
            maps.Add(map);
        }

        foreach (var map in maps)
        {
            string idStr = map[ID];
            string iconPath = map[ICON];
            string imagePath = map[TEXTURE];
            string theme = map[THEME];
            string time = map[TIME];
            string content = map[CONTENT];
            string collectStr = map[COLLECT];
            string likeStr = map[LIKE];

            int id = int.Parse(idStr);
            Sprite icon = AssetManager.LoadAssetFromAssetBundle<Sprite>("icon/" + iconPath);
            int collect = int.Parse(collectStr);
            int like = int.Parse(likeStr);
            
            PlazaData data = new PlazaData(id, icon, theme, time, content, null, like, collect);
            datas.Add(data);

            DataFactory.GetInstance().RequestImageData(id, imagePath, SetDataImage);
        }
    }

    
    public void SetDataImage(int id, Sprite spr)
    {
        dataSprite.Add(id, spr);
        if (dataSprite.Count == datas.Count)
        {
            foreach(var data in datas)
            {
                var temp = data;
                int key = temp.ID;
                temp.Textures = dataSprite[key];
            }

            _uiDataCB(true, datas);
        }
    }
}