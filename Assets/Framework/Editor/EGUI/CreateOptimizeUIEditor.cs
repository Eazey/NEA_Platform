
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  AssetManager.cs
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace EGUIFramework
{

	public class CreateOptimizeUIEditor : Editor {

        [MenuItem("GameObject/UI/Optimize Image")]
        static void CreatImage()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("UI_", typeof(Image));
                    go.transform.SetParent(Selection.activeTransform);

                    Image image = go.GetComponent<Image>();
                    image.raycastTarget = false;

                    RectTransform rect = go.GetComponent<RectTransform>();
                    rect.localPosition = Vector3.zero;
                    rect.localRotation = Quaternion.Euler(Vector3.zero);
                    rect.localScale = Vector3.one;
                    rect.anchorMax = 0.5f * Vector2.one;
                    rect.anchorMin = 0.5f * Vector2.one;
                    rect.pivot = 0.5f * Vector2.one;
                    rect.sizeDelta = new Vector2(300, 300);

                    Selection.activeTransform = go.transform;
                }
            }
        }

        [MenuItem("GameObject/UI/Optimize Text")]
        static void CreatText()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("Text_", typeof(Text));
                    go.transform.SetParent(Selection.activeTransform);

                    Text text = go.GetComponent<Text>();
                    text.raycastTarget = false;   
                    text.text = "New Text";
                    text.fontSize = 40;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.color = Color.black;
                    text.font = Resources.Load("Font/YaHei") as Font;

                    RectTransform rect = go.GetComponent<RectTransform>();
                    rect.localPosition = Vector3.zero;
                    rect.localRotation = Quaternion.Euler(Vector3.zero);
                    rect.localScale = Vector3.one;
                    rect.anchorMax = 0.5f * Vector2.one;
                    rect.anchorMin = 0.5f * Vector2.one;
                    rect.pivot = 0.5f * Vector2.one;
                    rect.sizeDelta = new Vector2(400, 100);

                    Selection.activeTransform = go.transform;
                }
            }
        }

        [MenuItem("GameObject/UI/Optimize Panel")]
        static void CreatPanel()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("Panel_", typeof(Image));
                    go.transform.SetParent(Selection.activeTransform);

                    Image image = go.GetComponent<Image>();
                    image.color = Color.white;
                    image.raycastTarget = false;

                    RectTransform rect = go.GetComponent<RectTransform>();
                    rect.localPosition = Vector3.zero;
                    rect.localRotation = Quaternion.Euler(Vector3.zero);
                    rect.localScale = Vector3.one;
                    rect.anchorMax = 0.5f * Vector2.one;
                    rect.anchorMin = 0.5f * Vector2.one;
                    rect.pivot = 0.5f * Vector2.one;
                    rect.sizeDelta = new Vector2(1080, 1920);

                    Selection.activeTransform = go.transform;
                }
            }
        }

        [MenuItem("GameObject/UI/Optimize Button")]
        static void CreatButton()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("Btn_", typeof(Image));
                    go.transform.SetParent(Selection.activeTransform);
                    go.AddComponent<Button>();

                    RectTransform buttonRect = go.GetComponent<RectTransform>();
                    buttonRect.localPosition = Vector3.zero;
                    buttonRect.localRotation = Quaternion.Euler(Vector3.zero);
                    buttonRect.localScale = Vector3.one;
                    buttonRect.anchorMax = 0.5f * Vector2.one;
                    buttonRect.anchorMin = 0.5f * Vector2.one;
                    buttonRect.pivot = 0.5f * Vector2.one;
                    buttonRect.sizeDelta = new Vector2(400, 100);

                    Selection.activeTransform = go.transform;
                }
            }
        }
    }
}