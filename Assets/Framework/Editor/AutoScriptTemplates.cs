
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  AutoScriptTemplates.cs
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
 * 用于自动设置版权样式可替换项
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;
using UnityEditor;

public class AutoScriptTemplates : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        string fileExtension = path.Substring(index);
        if (fileExtension != ".cs")
            return;

        index = Application.dataPath.LastIndexOf("Asset");
        path = Application.dataPath.Substring(0, index) + path;
        string file = System.IO.File.ReadAllText(path);

        file = file.Replace("#CREATEDATE#", System.DateTime.Now.ToString("d"));
        file = file.Replace("#PROJECTNAME#", PlayerSettings.productName);
        file = file.Replace("#SMARTDEVELOPERS#", PlayerSettings.companyName);
        file = file.Replace("#FILEEXTENSION#", fileExtension);

        System.IO.File.WriteAllText(path, file, System.Text.Encoding.UTF8);
        AssetDatabase.Refresh();
    }
}
