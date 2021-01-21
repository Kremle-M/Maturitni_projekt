using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Fire : MonoBehaviour
{

    Rigidbody2D rb;
    public Vector2 dir = new Vector2(0, 10);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dir;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Arrowwall"))
        {
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Player")) ;
        {
            Destroy(gameObject);
        }
    }
}