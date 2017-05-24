using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScriptableObjects;
using UnityEngine;

public class TestLoad : MonoBehaviour
{
    public BackPackConfig userPack;
    public BackPackConfig userloadPack;
    // Use this for initialization
    void Start()
    {
        //userPack.BackPackChange.AddListener(PrintItems);
        
        Load();
    }

    void PrintItems(BackPackConfig config)
    {
        config.Items.ForEach(n => Debug.Log(n.name));
    }

    void Save()
    {
        var path = @"C:\Users\donray.williams\AppData\LocalLow\DefaultCompany\BackPack Adventure\Test2.json";
        var obj = ScriptableObject.CreateInstance<BackPackConfig>();
        var json = JsonUtility.ToJson(userPack);
        File.WriteAllText(path, json);
    }

    void Load()
    {
        var path = @"C:\Users\donray.williams\AppData\LocalLow\DefaultCompany\BackPack Adventure\Test2.json";
        var json = File.ReadAllText(path);
        var asset = Resources.FindObjectsOfTypeAll<BackPackConfig>().FirstOrDefault();
        JsonUtility.FromJsonOverwrite(json, asset);
        userloadPack = asset;
    }


}
