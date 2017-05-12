using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    public BackPackConfig BackPackConfig; // Referencing the BackPackConfig
    public List<Item> Inventory; // List to add items to
    public int ListCapicty; // Variable to set equal to the capacity in the config 

    //private CombatKnife _knife; // Used for testing 

    private int _idcount;
    // Use this for initialization
    private void Start()
    {
        _idcount = 0;
        Inventory = new List<Item>();
        //_knife = new CombatKnife();
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
    //        RemoveAllFromStash();
    //}
    /// Adding in any item taken in to the list if not over Capicity
    public void AddToStash(Item item)
    {
        if (Inventory.Count >= ListCapicty) return;
        Inventory.Add(item);
        BackPackChange.Invoke(this);
        AddInfo(item);
    }
    // Add item at given index
    //public void AddToStashAtIndex(Item item, int choosenIndexAt)
    //{
    //    if (Inventory.Count >= ListCapicty) return;
    //    if (choosenIndexAt > ListCapicty || choosenIndexAt < 0) return;
    //    Inventory.Insert(choosenIndexAt, item);
    //    AddInfo(item);
    //}
    /// If the list contains the item remove it from the list
    public void RemoveFromStash(Item item)
    {
        if (Inventory == null) return;
        if (!Inventory.Contains(item)) return;
        Inventory.Remove(item);
        BackPackChange.Invoke(this);
        Debug.Log("Removed: " + item.GetType().ToString() + " " + _idcount);
    }
    [ContextMenu("Delete List")]
    // New ups the list and adds the backpackconfig back
    public void RemoveAllFromStash()
    {
        if (Inventory == null) return;
        BackPackChange.Invoke(this);
        Inventory = new List<Item>();
        Debug.Log("Cleared Inventory");
        foreach (var i in BackPackConfig.Items)
        {
            var startItems = Instantiate(i);
            AddToStash(startItems);
        }
    }
    // Used in more then once place
    private void AddInfo(Item item)
    {
        _idcount++;
        item.Identification = _idcount;
        item.Name = gameObject.name + _idcount;
        Debug.Log("Added: " + item.ToString() + " " + _idcount);
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

    public class OnBackPackChange : UnityEvent<BackPack>
    {

    }
    public OnBackPackChange BackPackChange = new OnBackPackChange();
}