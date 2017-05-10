using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPack : MonoBehaviour
{

    public List<ScriptableObjects.Item> Inventory;
    private int test;
    private int ID_Count;
    //public GameObject swordPrefab;
    //public GameObject contentWindow;
    //public GameObject shieldPrefab;
    // Use this for initialization
    void Start()
    {
        ID_Count = 0;
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
}
    
//    void AddKnife()
//    {
//        var go = Instantiate(swordPrefab, contentWindow.transform);

//        go.AddComponent<DestroyAfterTime>();
//        var sprites = Resources.LoadAll<Sprite>("sword_sprites");
//        var numsprites = sprites.Length;
//        var randomSprite = Random.Range(0, numsprites);
//        go.GetComponent<Image>().sprite = sprites[randomSprite];
//    }
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
