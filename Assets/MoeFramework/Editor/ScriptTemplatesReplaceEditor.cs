
// ------------------------------ //
// Product Name : MovieWorld
// Company Name : MOESTONE
// Author  Name : Eazey Wang
// Editor  Data : 11/27/2017
// ------------------------------ //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptTemplatesReplaceEditor : UnityEditor.AssetModificationProcessor{

    const string FRAMEWORK_NAME = "MovieWorldFramework";

    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        string file = path.Substring(index);

        if (file != ".cs" && file != ".js" && file != ".boo")
            return;

        string fileExtension = file;

        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        file = System.IO.File.ReadAllText(path);

        file = file.Replace("#FRAMEWORKNAME#", FRAMEWORK_NAME);
        file = file.Replace("#EDITORDATA#", System.DateTime.Now.ToString("d"));
        file = file.Replace("#PRODUCTNAME#", PlayerSettings.productName);
        file = file.Replace("#COMPANYNAME#", PlayerSettings.companyName);
        file = file.Replace("#AUTHORNAME#", "");
        file = file.Replace("#FILEEXTENSION#", fileExtension);

        System.IO.File.WriteAllText(path, file, System.Text.Encoding.UTF8);
        AssetDatabase.Refresh();
    }

}
