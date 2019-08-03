using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * speed;
        rigidbody.AddForce(horizontalMovement * Vector2.right);
        if (Input.GetButton("Jump"))
            rigidbody.AddForce(Vector2.up * 30);
    }
}
