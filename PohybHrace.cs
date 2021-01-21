using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PohybHrace : MonoBehaviour
{

    public float movespeed = 10;
    public float jumpspeed = 15;
    public float distancetoground = 1;
    public float jumptime;
    private float healthStatusWidth;

    public GameObject screen;

    private End_Screen dm;

    Rigidbody2D rb;

    BoxCollider2D bc;

    int groundmask;
    private int health = 100;
    public int deaths;

    bool isTurned = false;

    public Text timeText;

    public Image healthStatus;

    public static PohybHrace instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();

        groundmask = LayerMask.GetMask("Platform");
        healthStatusWidth = healthStatus.rectTransform.rect.width;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                End_Screen.instance.ShowPauseScreen();
            }
            else
            {
                End_Screen.instance.UnPauseGame();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F1))
        {
            End_Screen.instance.ShowEndScreen();
        }

        float horizontalInput = Input.GetAxis("Horizontal");

       

        if (horizontalInput < 0 && !isTurned)
        {
            transform.localScale = new Vector2(-1, 1);
            isTurned = true;
        }
        else if (horizontalInput > 0 && isTurned)
        {
            transform.localScale = new Vector2(1, 1);
            isTurned = false;
        }
        Vector2 vel = rb.velocity;

        vel.x = (transform.right * movespeed * horizontalInput).x;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            vel.y = (transform.up * jumpspeed).y;
        }

        rb.velocity = vel;

        if(jumptime > 0)
        {
            jumptime -= Time.deltaTime;
        }
        else
        {
            jumpspeed = 13;
        }
    }

    private bool IsGrounded()
    {
        Vector2 rayStartPosition = transform.position;
        rayStartPosition.y -= (bc.bounds.size.y / 2);

        Debug.DrawRay(rayStartPosition, Vector2.down * distancetoground, Color.red, 1);

        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, Vector2.down, distancetoground, groundmask);

        if (hit)
        {
            Debug.Log("hit");
            return true;
        }
        return false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision" + collision.collider.name);

        if (health >= 100)
        {
            if (collision.collider.CompareTag("Heal"))
            {
                health += 0;
            }
        }
        else if (collision.collider.CompareTag("Heal"))
        {
            health += 50;
        }
        if (health > 0)
        {
            if (collision.collider.CompareTag("Saw"))
            {
                health -= 100;
            }
            else if (collision.collider.CompareTag("Spike"))
            {
                health -= 50;
            }
            else if (collision.collider.CompareTag("JumpPad"))
            {
                jumpspeed = 20;
                jumptime = 1.5f;
            }
            else if (collision.collider.CompareTag("Arrow"))
            {
                health -= 50;
            }
            else if (collision.collider.CompareTag("Enemy"))
            {
                health -= 100;
            }

            float rightOffset = -(healthStatusWidth - ((healthStatusWidth / 100) * health));

            healthStatus.rectTransform.offsetMax = new Vector2(rightOffset, 0);

        }

        if (health >= 90)
        {
            healthStatus.color = Color.green;
        }

        if (health <= 60)
        {
            healthStatus.color = Color.yellow;
        }

        if (health <= 30)
        {
            healthStatus.color = Color.red;
        }

        if (health <= 0)
        {
            healthStatusWidth = 0;
            End_Screen.instance.ShowEndScreen();

        }
    }

}


