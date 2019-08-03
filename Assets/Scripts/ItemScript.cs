using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
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
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().typeKey = 1;
            collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color = new Color(0, 30, 255);
        }
    }
}
