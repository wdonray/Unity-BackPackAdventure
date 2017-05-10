using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjects: MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

}
