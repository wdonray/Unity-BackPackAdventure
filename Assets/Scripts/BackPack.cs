using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;
#if UNITY_EDITOR
using UnityEditor;

#endif
public class BackPack : MonoBehaviour
{
    public string FileNameToSave;
    private int _idcount;

    public OnBackPackChange BackPackChange = new OnBackPackChange();
    public BackPackConfig BackPackConfig; // Referencing the BackPackConfig
    public List<Item> Inventory; // List to add items to
    public int ListCapicty; // Variable to set equal to the capacity in the config 
    public List<Item> __Inventory = new List<Item>();
    private BackPackConfig currentBackPack;

    // Use this for initialization
    private void Start()
    {
        _idcount = 0;
        Inventory = new List<Item>();
        currentBackPack = ScriptableObject.CreateInstance<BackPackConfig>();
        if (BackPackConfig == null)
            BackPackConfig = LoadBackPack(FileNameToSave);
        Assert.IsNotNull(BackPackConfig);
        Assert.IsNotNull(BackPackConfig.Items, "no items");
        BackPackConfig.Items.ForEach(AddToStash);
    }
    /// Adding in any item taken in to the list if not over Capicity
    public void AddToStash(Item item)
    {
        Inventory.Add(item);
        BackPackChange.Invoke(currentBackPack);
        currentBackPack.InitInventory = Inventory;
    }

    /// If the list contains the item remove it from the list
    public void RemoveFromStash(Item item)
    {
        _idcount--;
        if (Inventory == null) return;
        if (!Inventory.Contains(item)) return;
        Inventory.Remove(item);
        BackPackChange.Invoke(currentBackPack);
        Debug.Log("Removed: " + item.GetType() + " " + _idcount);
        currentBackPack.InitInventory = Inventory;
    }

    [ContextMenu("Delete List")]
    // New ups the list and adds the backpackconfig back
    public void RemoveAllFromStash()
    {
        if (Inventory == null) return;
        BackPackChange.Invoke(currentBackPack);
        Inventory = new List<Item>();
        foreach (var i in BackPackConfig.Items)
        {
            var startItems = Instantiate(i);
            AddToStash(startItems);
        }
        currentBackPack.InitInventory = Inventory;
    }
    // Raise the list capacity
    public void RaiseCapacity(int amount)
    {
        ListCapicty += amount;
        Debug.Log("Raised Capacity by:" + amount);
    }

    // Lower the list capacity
    public void LowerCapacity(int amount)
    {
        ListCapicty -= amount;
        Debug.Log("Lowered Capacity by:" + amount);
    }

    public void SaveBackPack(string filename, BackPackConfig backPack)
    {
        var json = JsonUtility.ToJson(currentBackPack, true);
        var path = Application.persistentDataPath + string.Format("/{0}.json", filename);
        File.WriteAllText(path, json);
    }

    public void Save()
    {
        SaveBackPack(FileNameToSave, currentBackPack);
        BackPackChange.Invoke(currentBackPack);
    }

    public void Load()
    {
        currentBackPack = LoadBackPack(FileNameToSave);
        BackPackChange.Invoke(currentBackPack);
        currentBackPack.InitInventory = Inventory;
    }
    public BackPackConfig LoadBackPack(string filename)
    {
        var backpack = ScriptableObject.CreateInstance<BackPackConfig>();
        var path = Application.persistentDataPath + string.Format("/{0}.json", filename);
        var json = File.ReadAllText(path);
        #region Editor
#if UNITY_EDITOR
        var backPackAsset = AssetDatabase.FindAssets("t:BackPackConfig")
            .Select(AssetDatabase.AssetPathToGUID)
            .Select(AssetDatabase.LoadAssetAtPath<BackPackConfig>)
            .Where(b => b)
            .ToArray();
        backpack = backPackAsset.FirstOrDefault();
#endif
        #endregion
        if (backpack == null)
            backpack = ScriptableObject.CreateInstance<BackPackConfig>();
        Assert.IsNotNull(backpack, "BackPack should not be null");
        var asset = Resources.FindObjectsOfTypeAll<BackPackConfig>().FirstOrDefault();
        JsonUtility.FromJsonOverwrite(json, asset);
        backpack = asset;
        foreach (var b in backpack.Items)
        {
            __Inventory.Add(b);
        }
        return backpack;
    }

    [Serializable]
    public class OnBackPackChange : UnityEvent<BackPackConfig>
    {
    }
}