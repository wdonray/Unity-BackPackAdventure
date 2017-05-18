using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILog : MonoBehaviour
{

    public Text text;
    public float time = 2.0f;
    private void Start()
    {
        text.text = "";
    }

    private void Update()
    {
        if (time < 0)
        {
            text.text = " ";
            time = 2.0f;
        }
        time -= Time.deltaTime;
    }


    public void OnItemAction(ScriptableObjects.Item item)
    {
        text.text = item.name + "\n";

    }

}
