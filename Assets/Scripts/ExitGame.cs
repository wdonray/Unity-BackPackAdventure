using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{

    public Button b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            b.enabled = false;

        Application.Quit();
    }
}
