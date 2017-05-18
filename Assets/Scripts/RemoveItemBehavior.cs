using UnityEngine;

public class RemoveItemBehavior : MonoBehaviour
{
    private BackPack playerBackPack;
    public GameObject prefab;

    // Use this for initialization
    private void Start()
    {
        playerBackPack = GetComponent<BackPack>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GetComponent<BackPack>().Inventory.Count <= 0)
            return;

        if (!Input.GetKeyDown(KeyCode.I))
            return;

        var randomItemIndex = Random.Range(0, playerBackPack.Inventory.Count - 1);
        var itemToRemove = playerBackPack.Inventory[randomItemIndex];
        playerBackPack.RemoveFromStash(itemToRemove);

        var removedItemGameObject = Instantiate(prefab, transform.localPosition + Vector3.up * 5f, transform.rotation);
        removedItemGameObject.GetComponent<ItemPickUpBehavior>().item_config = itemToRemove;
        
    }

}