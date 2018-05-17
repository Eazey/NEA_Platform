
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  AssetManager.cs
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
 * 用来加载资源
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace EGUIFramework
{
    public static class AssetManager
    {
        public const string FixTextBtnPath = "UI/FixTextBtn";
        public const string PlazaCellPath = "UI/PlazaCell";
        public const string PlazaContentPath = "UI/PlazaContent";


        private static Dictionary<string, AssetBundle> assetBundleDic;
        private static AssetBundleManifest manifests;
        private static string defaultPath;

        static AssetManager()
        {
            assetBundleDic = new Dictionary<string, AssetBundle>();
            //InitManifest();
            defaultPath =
#if UNITY_ANDROID
           "jar:file://" + Application.dataPath + "!/assets/ANDROID/";
#elif UNITY_IOS
        Application.streamingAssetsPath + "/iOS/";
#elif UNITY_STANDALONE
           "file://" + Application.dataPath + "/StreamingAssets/WIN/";
#endif
        }

        /// <summary>
        /// 初始化Manifest
        /// </summary>
        private static void InitManifest()
        {
            AssetBundle ab =
#if UNITY_ANDROID
AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/ANDROID/ANDROID");
#elif UNITY_IOS
                AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/iOS/iOS");
#elif UNITY_STANDALONE
                AssetBundle.LoadFromFile("file://" + Application.dataPath + "/StreamingAssets/WIN/WIN");
#endif
            manifests = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");

            if (manifests != null)
                ab.Unload(false);
        }
        /// <summary>
        /// 同步加载 Resources 目录下指定类型资源
        /// </summary>
        /// <typeparam name="T"> 继承自 UnityEngine.Object 的资源类型 </typeparam>
        /// <param name="path"> 资源相对 Resources 路径（不带扩展名，开头不加斜杠） </param>
        /// <returns></returns>
        public static T LoadAssetsFormResource<T>(string path)
            where T : UnityEngine.Object
        {
            T obj = Resources.Load<T>(path);
            if (obj == null)
            {
                Debug.LogError("Assets file path not be found in Resources: " + path);
            }
            if (obj.name.Contains("Clone"))
                obj.name = obj.name.Replace("Clone", "");

            return obj;
        }

        public static GameObject LoadGameObject(string path)
        {
            GameObject prefab = LoadAssetsFormResource<GameObject>(path);
            GameObject go = GameObject.Instantiate(prefab);
            return go;
        }

        public static void SetParent(GameObject go, GameObject parent)
        {
            Transform trans = go.transform;
            trans.SetParent(parent.transform);
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }


        /// <summary>
        /// 异步加载指定AssetBundle,并加入管理
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static IEnumerator LoadAssetBundleAsync(string name)
        {
            AssetBundleCreateRequest request;
            if (assetBundleDic.ContainsKey(name))
            {
                Debug.Log("该AssetBundle已被加载");
                yield break;
            }
            else
            {
                request = AssetBundle.LoadFromFileAsync(defaultPath + name);
                yield return request;
                assetBundleDic.Add(name, request.assetBundle);
            }
        }

        /// <summary>
        /// 异步加载指定AssetBundle极其所有依赖关系
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static IEnumerator LoadAssetBundleAndDependenciesAsync(string name)
        {

            if (assetBundleDic.ContainsKey(name))
            {
                Debug.Log("该AssetBundle已被加载 :" + name);
            }
            else
            {
                string[] names = manifests.GetDirectDependencies(name);
                foreach (var item in names)
                {
                    yield return LoadAssetBundleAndDependenciesAsync(item);
                }
                yield return LoadAssetBundleAsync(name);
            }
        }

        /// <summary>
        /// 异步加载指定资源, 通过委托对资源进行处理
        /// </summary>
        /// <param name="path">资源所在路径 , 格式: 指定资源所在AB包名/指定资源名</param>
        /// <param name="callback">对资源进行处理的回调</param>
        /// <returns></returns>
        public static IEnumerator LoadAssetFromAssetBundleAsync<T>(string path, Action<T> callback) where T : UnityEngine.Object
        {
            string[] abPath = path.Split('/');
            AssetBundleRequest request;
            yield return LoadAssetBundleAndDependenciesAsync(abPath[0]);
            if (assetBundleDic.ContainsKey(abPath[0]))
            {
                request = assetBundleDic[abPath[0]].LoadAssetAsync(abPath[1]);
                yield return request;
                callback(request.asset as T);
            }
        }

        /// <summary>
        /// 异步加载指定AB包中的所有资源
        /// </summary>
        /// <param name="name">指定AB包</param>
        /// <param name="callback">对资源进行处理的回调</param>
        /// <returns></returns>
        public static IEnumerator LoadAllAssetsFromAssetBundleAsync<T>(string name, Action<T[]> callback) where T : UnityEngine.Object
        {
            AssetBundleRequest request;
            yield return LoadAssetBundleAndDependenciesAsync(name);
            if (assetBundleDic.ContainsKey(name))
            {
                request = assetBundleDic[name].LoadAllAssetsAsync();
                yield return request;
                callback(request.allAssets as T[]);
            }
        }



        /// <summary>
        /// 从streamingAssets中加载指定的AB包,并加入管理
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static void LoadAssetBundle(string name)
        {
            AssetBundle ab;
            if (assetBundleDic.ContainsKey(name))
            {
                Debug.Log("该AssetBundle已被加载 : " + name);
                return;
            }
            else
            {
                ab = AssetBundle.LoadFromFile(defaultPath + name);
                if (ab != null)
                    assetBundleDic.Add(name, ab);
            }
        }

        /// <summary>
        /// 加载指定AssetBundle及其所有依赖关系
        /// </summary>
        /// <param name="name"></param>
        private static void LoadAssetBundleAndDependencies(string name)
        {
            if (assetBundleDic.ContainsKey(name))
            {
                Debug.Log("该AssetBundle已被加载");
                return;
            }
            else
            {
                string[] names = manifests.GetDirectDependencies(name);
                foreach (var item in names)
                {
                    LoadAssetBundleAndDependencies(item);
                }
                LoadAssetBundle(name);
            }
        }


        /// <summary>
        /// 同步加载指定AssetBundle中的全部资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T[] LoadAllAssetsFromAssetBundle<T>(string name) where T : UnityEngine.Object
        {
            LoadAssetBundleAndDependencies(name);
            if (assetBundleDic.ContainsKey(name))
            {
                T[] result = assetBundleDic[name].LoadAllAssets<T>();
                if (result.Length != 0)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// 同步加载指定AssetBundle中的指定资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">资源所在路径 , 格式: 指定资源所在AB包名/指定资源名</param>
        /// <returns></returns>
        public static T LoadAssetFromAssetBundle<T>(string path) where T : UnityEngine.Object
        {
            string[] abPath = path.Split('/');
            LoadAssetBundleAndDependencies(abPath[0]);
            if (assetBundleDic.ContainsKey(abPath[0]))
            {
                T result = assetBundleDic[abPath[0]].LoadAsset<T>(abPath[1]);
                if (result)
                    return result;
            }
            Debug.Log("该资源不存在 : " + abPath[1]);
            return null;
        }

        public static bool ResourceLoad<TOut>(string path, out TOut asset)
            where TOut : UnityEngine.Object
        {
            bool result = false;
            asset = Resources.Load<TOut>(path);
            if (asset != null)
                result = true;
            return result;
        }

        public static bool ResourceLoadObj(string path, out GameObject go, Transform parent = null)
        {
            bool result = false;
            go = null;

            GameObject prefab;
            if (ResourceLoad<GameObject>(path, out prefab))
            {
                if (parent != null)
                    go = GameObject.Instantiate(prefab, parent);
                else
                    go = GameObject.Instantiate(prefab);

                Resources.UnloadAsset(prefab);
            }
            return result;
        }

        /// <summary>
        /// 卸载指定AssetBundle包
        /// </summary>
        /// <param name="name">指定AB包名</param>
        /// <param name="deleteLoadedAssets">是否卸载该AB包中已实例化的资源</param>
        private static void UnloadAssetBundle(string name, bool deleteLoadedAssets)
        {
            if (assetBundleDic.ContainsKey(name))
            {
                assetBundleDic[name].Unload(deleteLoadedAssets);
                assetBundleDic.Remove(name);
            }
        }

        /// <summary>
        /// 卸载所有已加载AB包
        /// </summary>
        /// <param name="deleteLoadedAssets">是否删除已实例化资源</param>
        private static void UnloadAllAssetBundle(bool deleteLoadedAssets)
        {
            foreach (var item in assetBundleDic.Values)
            {
                item.Unload(deleteLoadedAssets);
            }
            assetBundleDic.Clear();
        }

    }
}