using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructingScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coll Destructing");
        if (collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color == gameObject.GetComponent<DestructingScript>().spriteRenderer.color)
        {
            Debug.Log("Correct Type :)");
        }
        else
        {
            Debug.Log("Boom!!!Game Over=(");
            Destroy(collision.gameObject);
        }
    }
}
