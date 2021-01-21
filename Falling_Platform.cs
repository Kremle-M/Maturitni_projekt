using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Platform : MonoBehaviour
{
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, PohybHrace.instance.transform.position);

        if (distanceToTarget < 2)
        {
            Destroy(gameObject);
        }
    }
}
