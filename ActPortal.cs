using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActPortal : MonoBehaviour
{
    public GameObject Wheal;
    public GameObject Portal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wheal"))
        {
            Portal.SetActive(true);
            Object.Destroy(Wheal);
            Destroy(gameObject);
        }
    }
}
