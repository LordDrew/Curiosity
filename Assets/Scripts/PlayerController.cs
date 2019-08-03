using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    public float speed = 10f;
    public float jumpHeight = 1f;

    float groundRaycastDistance = 0.52f;
    Vector3 velocity = Vector3.zero;

    new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal") * speed;
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(horizontalMovement, rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, 0.05f);

        if (Input.GetButton("Jump") && IsGrounded())
            rigidbody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, groundRaycastDistance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        hit = Physics2D.Raycast(transform.position + Vector3.left * 0.5f, direction, groundRaycastDistance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        hit = Physics2D.Raycast(transform.position - Vector3.left * 0.5f, direction, groundRaycastDistance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position + Vector3.left * 0.5f, Vector2.down*groundRaycastDistance, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * groundRaycastDistance, Color.green);
        Debug.DrawRay(transform.position - Vector3.left * 0.5f, Vector2.down * groundRaycastDistance, Color.green);
    }
}
