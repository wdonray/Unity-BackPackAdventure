using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBackPackCounter : MonoBehaviour
{

    public Text TheText;

    private void Start()
    {
        TheText = GetComponent<Text>();
    }

    public void UpdateText(BackPack bag)
    {
        if (bag.Inventory.Count < bag.ListCapicty)
            TheText.text = bag.Inventory.Count.ToString();
        else
            TheText.text = bag.Inventory.Count.ToString() + " Maxed";
    }
}
