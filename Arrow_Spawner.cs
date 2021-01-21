using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Spawner : MonoBehaviour
{

    public Arrow_Fire arrowPrefab;

    public float arrowSpeed;
    public float arrowFall;
    private float time = 0;
    public float arrowDelay;

    public bool Randomspawn = false;
    public bool boss = false;
    public bool fromLeft = false;
    public bool fromUp = false;
    public bool shoot;

    private Vector2 dir2;

    void Start()
    {
        dir2 = new Vector2(arrowSpeed, arrowFall);
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot == true)
        {
            if (time < Time.time)
            {
                Arrow_Fire arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as Arrow_Fire;
                arrow.dir = dir2;
                if (fromLeft == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 180-45);
                }
                else 
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 0-45);
                }
                if(fromUp == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 270 - 45);
                }
                if (boss == true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (Randomspawn == true)
                {
                    arrowDelay = Random.Range(0, 15);
                }
                time = Time.time + arrowDelay;
            }
        }
    }
}
