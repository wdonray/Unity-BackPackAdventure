﻿using UnityEngine;

public class RemoveItemBehavior : MonoBehaviour
{
    private BackPackBehaviour playerBackPack;
    public GameObject prefab;

    // Use this for initialization
    private void Start()
    {
        playerBackPack = GetComponent<BackPackBehaviour>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GetComponent<BackPackBehaviour>().Inventory.Count <= 0)
            return;

        if (!Input.GetKeyDown(KeyCode.I))
            return;

        var randomItemIndex = Random.Range(0, playerBackPack.Inventory.Count - 1);
        var itemToRemove = playerBackPack.Inventory[randomItemIndex];
        playerBackPack.RemoveFromStash(itemToRemove);

        var removedItemGameObject = Instantiate(prefab, transform.localPosition + Vector3.up * 5f, prefab.transform.rotation);
        removedItemGameObject.GetComponent<ItemPickUpBehavior>().item_config = itemToRemove;
        
    }

}