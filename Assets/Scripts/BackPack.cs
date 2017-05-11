using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;
public class BackPack : MonoBehaviour
{
    public BackPackConfig Start_Items;
    public List<Item> Inventory;
    public int Capacity;

    private CombatKnife Knife;

    // Use this for initialization
    void Start()
    {
        Start_Items = new BackPackConfig();
        Inventory = new List<Item>();
        Knife = new CombatKnife();
        foreach (var i in Start_Items.Items)
        {
            var StartItems = Instantiate(i);
            Add(StartItems);
        }
        Capacity = Start_Items.Capacity;
    }
    // Testing: Working
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        Add(Knife);
    //    else if (Input.GetKeyDown(KeyCode.S))
    //        Remove(Knife);
    //}
    void Add(Item item)
    {
        if (Inventory.Count < Capacity)
        {
            Inventory.Add(item);
            Debug.Log("Added item: " + item.name);
        }
    }
    void Remove(Item item)
    {
        if (Inventory.Contains(item))
        {
            Inventory.Remove(item);
            Debug.Log("Removed item: " + item.name);
        }
    }
}