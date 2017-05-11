using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;
public class BackPack : MonoBehaviour
{
    public BackPackConfig backpackConfig;
    public List<Item> Inventory;
    public int listCapicty;

    private CombatKnife Knife;

    // Use this for initialization
    void Start()
    {
        Inventory = new List<Item>();
        Knife = new CombatKnife();
        listCapicty = backpackConfig.Capacity;
        foreach (var i in backpackConfig.Items)
        {
            var startItems = Instantiate(i);
            AddToStash(startItems);
        }
    }
    // Testing: Working
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AddToStash(Knife);
        else if (Input.GetKeyDown(KeyCode.S))
            RemoveFromStash(Knife);
    }
    void AddToStash(Item item)
    {
        if (Inventory.Count < listCapicty)
            Inventory.Add(item);
    }
    void RemoveFromStash(Item item)
    {
        if (Inventory.Contains(item))
            Inventory.Remove(item);
    } 
}