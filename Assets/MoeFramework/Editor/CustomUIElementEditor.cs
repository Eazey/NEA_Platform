
// ------------------------------ //
// Product Name : CandyWorld
// Company Name : MOESTONE
// Author  Name : Eazey Wang
// Editor  Data : 1/9/2018
// ------------------------------ //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace MoeStoneFramework
{

	public class CustomUIElementEditor : Editor
    {

        [MenuItem("GameObject/UI/Image")]
        static void CreatImage()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("UI_", typeof(Image));
                    go.transform.SetParent(Selection.activeTransform);

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

        [MenuItem("GameObject/UI/Text")]
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
                    text.fontSize = 50;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.color = Color.black;
                    text.font = Resources.Load("Font/CandyFont") as Font;

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

        [MenuItem("GameObject/UI/Button")]
        static void CreatButton()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("Btn_", typeof(Image));     
                    go.transform.SetParent(Selection.activeTransform);
                    go.AddComponent<Button>();

                    GameObject child = new GameObject("Text_", typeof(Text));
                    child.transform.SetParent(go.transform);

                    RectTransform buttonRect = go.GetComponent<RectTransform>();
                    buttonRect.localPosition = Vector3.zero;
                    buttonRect.localRotation = Quaternion.Euler(Vector3.zero);
                    buttonRect.localScale = Vector3.one;
                    buttonRect.anchorMax = 0.5f * Vector2.one;
                    buttonRect.anchorMin = 0.5f * Vector2.one;
                    buttonRect.pivot = 0.5f * Vector2.one;
                    buttonRect.sizeDelta = new Vector2(400, 100);

                    Text text = child.GetComponent<Text>();
                    text.raycastTarget = false;
                    text.text = "New Text";
                    text.fontSize = 50;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.color = Color.black;
                    text.font = Resources.Load("Font/CandyFont") as Font;

                    RectTransform textRect = child.GetComponent<RectTransform>();
                    textRect.localPosition = Vector3.zero;
                    textRect.localRotation = Quaternion.Euler(Vector3.zero);
                    textRect.localScale = Vector3.one;
                    textRect.anchorMax =  Vector2.one;
                    textRect.anchorMin = Vector2.zero;
                    textRect.pivot = 0.5f * Vector2.one;
                    textRect.offsetMax = Vector2.zero;
                    textRect.offsetMin = Vector2.zero;

                    Selection.activeTransform = go.transform;
                }
            }
        }

        [MenuItem("GameObject/UI/Panel")]
        static void CreatPanel()
        {
            if (Selection.activeTransform)
            {
                if (Selection.activeTransform.GetComponentInParent<Canvas>())
                {
                    GameObject go = new GameObject("Panel_", typeof(Image));
                    go.transform.SetParent(Selection.activeTransform);

                    Image image = go.GetComponent<Image>();
                    image.color = Color.clear;
                    image.raycastTarget = true;

                    RectTransform rect = go.GetComponent<RectTransform>();
                    rect.localPosition = Vector3.zero;
                    rect.localRotation = Quaternion.Euler(Vector3.zero);
                    rect.localScale = Vector3.one;
                    rect.anchorMax = Vector2.one;
                    rect.anchorMin = Vector2.zero;
                    rect.pivot = 0.5f * Vector2.one;
                    rect.offsetMax = Vector2.zero;
                    rect.offsetMin = Vector2.zero;

                    Selection.activeTransform = go.transform;
                }
            }
        }
    }
}