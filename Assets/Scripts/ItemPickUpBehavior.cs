using System;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickUpBehavior : MonoBehaviour
{

    public Item item_config;
    public Item item_runtime;
    public CollisionEvent collisionEvent = new CollisionEvent();
    private void Start()
    {

        item_runtime = Instantiate(item_config);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        collisionEvent.Invoke(item_runtime);
        Debug.Log(string.Format("on trigger " + other.gameObject.name));
        other.gameObject.GetComponent<BackPack>().AddToStash(item_runtime);
        GetComponent<SpriteRenderer>().color = Color.red;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 1f);

        if (other.gameObject.CompareTag("Item"))
            other.transform.position += Vector3.left;

    }

    [Serializable]
    public class CollisionEvent : UnityEvent<Item>
    {
        
    }

}