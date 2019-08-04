using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color != gameObject.GetComponent<DoorScript>().spriteRenderer.color)
        {
            StartCoroutine(TemporaryNotTrigger());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dor Enter");
        Debug.Log("Player:" + collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color.ToString());
        Debug.Log("Door:" + gameObject.GetComponent<DoorScript>().spriteRenderer.color.ToString());
        if (collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color != gameObject.GetComponent<DoorScript>().spriteRenderer.color)
        {
            StartCoroutine(TemporaryNotTrigger());
        }
    }
    IEnumerator TemporaryNotTrigger()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>().spriteRenderer.color == gameObject.GetComponent<DoorScript>().spriteRenderer.color)
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
