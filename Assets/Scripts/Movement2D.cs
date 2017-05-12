using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement2D : MonoBehaviour
{ 
    public Text PlayerPosText;
    [Range(-10, 10)]
    public int Speed = 0;
    private Rigidbody2D _rb2D;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector2(moveHorizontal, moveVertical);
        _rb2D.AddForce(movement * Speed);
        PlayerPosText.text = this.transform.position.ToString();
    }
}
