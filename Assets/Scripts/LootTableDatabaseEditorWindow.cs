using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
public class LootTableDatabaseEditorWindow : EditorWindow
{
    private readonly GUIStyle _header = new GUIStyle();
    public List<LootTable> Tables;
    private static string _path;
    public static List<string> assetStrings;
    [MenuItem("Tools/LootTableDatabase")]
    private static void Init()
    {
        var window = EditorWindow.GetWindow((typeof(LootTableDatabaseEditorWindow)));
        window.Show();
        _path = Application.dataPath + "/Scripts/";
    }
    private void OnGUI()
    {
        _header.alignment = TextAnchor.MiddleCenter;
        _header.fontStyle = FontStyle.Italic;
        _header.fontSize = 40;
        _header.normal.textColor = Color.red;
        GUILayout.Label("Art Students...", _header);
        GUILayout.Space(25);
        if (GUILayout.Button("Button", GUILayout.ExpandWidth(false)))
        {
            Debug.Log("It Worked");
        }
        EditorGUILayout.LabelField(_path, GUILayout.ExpandWidth(true));
        //foreach (var VARIABLE in assetStrings)
        //{
        //    EditorGUILayout.TextField("Table", VARIABLE);
        //}
    }
}
