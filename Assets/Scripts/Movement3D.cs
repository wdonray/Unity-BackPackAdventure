using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [Range(1.0f, 25.0f)]
    public float Speed;
	// Update is called once per frame
    private void Update ()
	{
	    var h = Input.GetAxis("Horizontal");
	    var v = Input.GetAxis("Vertical");

        var move = new Vector3(h, v, 0);

	    transform.localPosition += move * Speed * Time.deltaTime ;
	}
}
