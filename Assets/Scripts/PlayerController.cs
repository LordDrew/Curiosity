using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float speed = 10f;
    public float jumpHeight = 1f;

    float groundRaycastDistance = 0.6f;

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
        if (Input.GetButton("Jump") && IsGrounded())
            rigidbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, groundRaycastDistance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, Vector2.down*groundRaycastDistance, Color.green);
    }
}
