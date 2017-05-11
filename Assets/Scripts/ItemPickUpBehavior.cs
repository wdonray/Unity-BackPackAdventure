using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpBehavior : MonoBehaviour {

    public ScriptableObjects.Item item_config;
    public ScriptableObjects.Item item_runtime;

    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BackPack>().Inventory.Add(item_runtime);
        }
    }
    
}
