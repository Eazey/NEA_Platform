
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  ViewController.cs
//  Create on 2/16/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 控制所有的界面
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace EGUIFramework
{
    public class ViewController : NormalSingleton<ViewController>
    {
        private static Dictionary<ViewName, string> _viewNameDic;
        private static Dictionary<ViewName, IView> _viewObjDic;

        private ViewController()
        {
            _viewObjDic = new Dictionary<ViewName, IView>();
            _viewNameDic = new Dictionary<ViewName, string>();

            RegisterViewName();
        }

        private static void RegisterViewName()
        {
            string[] names = Enum.GetNames(typeof(ViewName));
            foreach (var name in names)
            {
                ViewName temp = (ViewName)Enum.Parse(typeof(ViewName), name);
                _viewNameDic.Add(temp, name);
            }
            Debug.Log("Name dic have count:" + _viewNameDic.Count);
        }

        private static bool isExistView(ViewName name)
        {
            bool result = false;
            if (_viewObjDic.ContainsKey(name))
                result = true;
            else
                Debug.LogError(name + " is not be found in dic.");

            return result;
        }

        private static bool isExistViewName(ViewName name)
        {
            bool result = false;
            if (_viewNameDic.ContainsKey(name))
                result = true;
            else
                Debug.LogError(name + " is not be found in dic. Please check enum 'ViewName'.");

            return result;
        }

        private static void RegisterView(ViewName name, IView view)
        {
            if (_viewObjDic.ContainsKey(name))
                Debug.LogError(name + " already exist in dic.");
            else
                _viewObjDic.Add(name, view);
        }

        public static Transform RootCanvas { get; set; }

        public static void RegisterAllView(Transform root)
        {
            for (int i = 0; i < root.childCount; i++)
            {
                var child = root.GetChild(i);
                var view = child.GetComponent<IView>();
                if (view == null)
                {
                    Debug.LogWarning(child.name + " not inherit to 'IView'");
                    continue;
                }
                //view.Close();
                _viewObjDic.Add(view.Name, view);
            }
        }

        public static void ClearAllView()
        {
            if (_viewObjDic != null)
                _viewObjDic.Clear();
            else
                _viewObjDic = new Dictionary<ViewName, IView>();
        }

        public static void OpenView(ViewName open, Transform parent = null)
        {
            if (isExistView(open))
            {
                IView target = _viewObjDic[open];
                target.Open();
                return;
            }

            if (!isExistViewName(open))
                return;

            string path = Utility.Path.GetViewPath(open.ToString());

            GameObject go;
            if (!AssetManager.ResourceLoadObj(path, out go, parent))
            {
                Debug.LogError(path + ": have not be found prefab: " + open.ToString());
                return;
            }
            go = Utility.View.InitUIObj(go);

            IView view = go.GetComponent<IView>();
            if (view == null)
            {
                Debug.LogError(open + ". The prefab not be found script inherit IView.");
                return;
            }

            RegisterView(view.Name, view);

            view.Open();
        }

        public static void CloseView(ViewName close)
        {
            if (isExistView(close))
            {
                IView view = _viewObjDic[close];
                view.Close();
            }
            else
            {
                Debug.LogError(close + " is not be opened.");
            }
        }

        public static void TranserView(ViewName close, ViewName open)
        {
            CloseView(close);
            OpenView(open);
        }
    }
}
