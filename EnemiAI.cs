using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAI : MonoBehaviour
{

    public GameObject Player;

    public float speed;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < distance)
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Saw"))  
        {

            Destroy(gameObject);
        }
    }
}
