using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public Text FpsText;
    public float Fps { get; private set; }
    // Update is called once per frame
    private void Update()
    {
        Fps = (float) (1f / Time.unscaledDeltaTime);
        Fps = Mathf.Round(Fps * 100f) / 100f;
        FpsText.text = Fps.ToString();
    }
}
