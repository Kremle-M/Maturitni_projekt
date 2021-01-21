using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death_Manager : MonoBehaviour
{
    public int deaths = 0;
    public Text deathText;

    public void IncreaseDeaths()
    {
        deaths += 1;
        deathText.text = deaths.ToString();
    }
}
