using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects;
public class BackPack : MonoBehaviour
{
    public BackPackConfig Start_Items;
    public List<Item> Inventory = new List<Item>();
    public int Capacity;

    // Use this for initialization
    void Start()
    {
        Capacity = Start_Items.Capacity;
    }
    void Add(Item item)
    {
        if (Inventory.Count < Capacity)
            Inventory.Add(Instantiate(item));
    }
    void Remove(Item item)
    {
        if (Inventory.Contains(item))
            Inventory.Remove(item);
    }
}
    // Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        test = Random.Range(0, 4);
    //        ID_Count++;
    //        if (test == 0)
    //        {
    //            var Vest = new ScriptableObjects.KevlarVest();
    //            Vest.Identification = ID_Count;
    //            Vest.Name = "KevlarVest" + ID_Count;
    //            Inventory.Add(Vest);
    //        }
    //        else if (test == 1)
    //        {
    //            var Knife = new ScriptableObjects.CombatKnife();
    //            Knife.Identification = ID_Count;
    //            Knife.Name = "CombatKnife" + ID_Count;
    //            Inventory.Add(Knife);
    //            //AddKnife();
    //        }
    //        else if (test == 2)
    //        {
    //            var Shield = new ScriptableObjects.CombatShield();
    //            Shield.Identification = ID_Count;
    //            Shield.Name = "CombatShield" + ID_Count;
    //            Inventory.Add(Shield);
    //            //AddShield();
    //        }
    //        else
    //        {
    //            var Gun = new ScriptableObjects.BerettaM92();
    //            Gun.Identification = ID_Count;
    //            Gun.Name = "Beretta M92" + ID_Count;
    //            Inventory.Add(Gun);
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.Delete))
    //        Inventory.Clear();
    //}
//    void AddKnife()
//    {
//        var Knife = new ScriptableObjects.CombatKnife();
//        Knife.Identification = ID_Count;
//        Knife.Name = "CombatKnife" + ID_Count;
//        Inventory.Add(Knife);
//        Inventory_Text.text += Knife.name;
//    }
//}


//    void AddShield()
//    {
//        var go = Instantiate(shieldPrefab, contentWindow.transform);

//        go.AddComponent<DestroyAfterTime>();
//        var sprites = Resources.LoadAll<Sprite>("VioletSpriteSheet");
//        var numsprites = sprites.Length;
//        var randomSprite = Random.Range(0, numsprites);
//        go.GetComponent<Image>().sprite = sprites[randomSprite];
//    }
//}
