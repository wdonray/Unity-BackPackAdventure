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

    public void UpdateText(BackPackBehaviour bag)
    {
        TheText.text = "Items: \n";
        if (bag.Inventory == null)
            TheText.text = "Empty";
        else
            foreach (var item in bag.Inventory)
                TheText.text += item.name + "\n";
    }
}
