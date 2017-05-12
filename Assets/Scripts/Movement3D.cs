using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    private float speed = 25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var h = Input.GetAxis("Horizontal");
	    var v = Input.GetAxis("Vertical");

        var move = new Vector3(h, v, 0);

	    transform.localPosition += move * speed * Time.deltaTime ;
	}
}
