using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;
public class BackPack : MonoBehaviour
{
    public BackPackConfig BackPackConfig; // Referencing the BackPackConfig
    public List<Item> Inventory; // List to add items to
    public int ListCapicty; // Variable to set equal to the capacity in the config 

    private CombatKnife _knife; // Used for testing 

    // Use this for initialization
    private void Start()
    {
        Inventory = new List<Item>();
        _knife = new CombatKnife();
        ListCapicty = BackPackConfig.Capacity;
        foreach (var i in BackPackConfig.Items)
        {
            var startItems = Instantiate(i);
            AddToStash(startItems);
        }
    }
    // Testing: Working
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        AddToStash(_knife);
    //    else if (Input.GetKeyDown(KeyCode.S))
    //        RemoveFromStash(_knife);
    //}

    // Adding in any item taken in to the list if not over Capicity
    public void AddToStash(Item item)
    {
        if (Inventory.Count >= ListCapicty) return;
        Inventory.Add(item);
        Debug.Log("Added: " + item.GetType().ToString());
    }
    // If the list contains the item remove it from the list
    public void RemoveFromStash(Item item)
    {
        if (Inventory == null) return;
        if (!Inventory.Contains(item)) return;
        Inventory.Remove(item);
        Debug.Log("Removed: " + item.GetType().ToString());
    }
    [ContextMenu("Delete List")]
    // New ups the list and adds the backpackconfig back
    public void RemoveAllFromStash()
    {
        if (Inventory == null) return;
        Inventory = new List<Item>();
        foreach (var i in BackPackConfig.Items)
        {
            var startItems = Instantiate(i);
            AddToStash(startItems);
        }
    }

}