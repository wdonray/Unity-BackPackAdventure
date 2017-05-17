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
        TheText.text = "Items: \n";
        foreach (var item in bag.Inventory)
            TheText.text += item.name + "\n";
    }
}
