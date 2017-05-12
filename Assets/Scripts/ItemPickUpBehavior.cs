using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpBehavior : MonoBehaviour
{

    public ScriptableObjects.Item item_config;
    public ScriptableObjects.Item item_runtime;

    private void Start()
    {
        item_runtime = Instantiate(item_config);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        Debug.Log(string.Format("on trigger " + other.gameObject.name));
        other.gameObject.GetComponent<BackPack>().AddToStash(item_runtime);
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1f);
    }


}
