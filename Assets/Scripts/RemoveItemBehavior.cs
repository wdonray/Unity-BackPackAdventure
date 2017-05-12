using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (GetComponent<BackPack>().Inventory.Count <= 0) return;
	    if (!Input.GetKeyDown(KeyCode.I)) return;
	    var i = Random.Range(0, GetComponent<BackPack>().Inventory.Count - 1);
	    var test = GetComponent<BackPack>().Inventory[i];
	    GetComponent<BackPack>().RemoveFromStash(test);
	}
}
