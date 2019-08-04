using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGIRRED!!!! (2D)");
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("TRIGIRRED!!!! (Player)");
            Debug.Log(collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color.ToString());
            collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color = gameObject.GetComponent<ItemScript>().spriteRenderer.color;
            Destroy(gameObject);
        }
    }
}
