using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public static JumpPad instance;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player")) ;
        {
            
            Destroy(gameObject);
        }

    }
}