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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger" + other.gameObject.name);
        
        other.gameObject.GetComponent<BackPack>().AddToStash(item_runtime);
       
    }
    
}
