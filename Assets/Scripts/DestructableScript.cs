using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableScript : MonoBehaviour
{
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
        Debug.Log("Coll");
        if (collision.gameObject.GetComponent<PlayerController>().typeKey == 1)
        {
            Debug.Log("Boom!!!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Wrong Type :(");
        }
    }
}
