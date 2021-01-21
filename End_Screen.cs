using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End_Screen : MonoBehaviour
{
    public static End_Screen instance;
    public int deaths = 0;
    public Text deathtext;

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
        gameObject.SetActive(false);
    }

    public void ShowEndScreen()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        deaths += 1;
        deathtext.text = "Umřel jsi ";  // dodělat counter na smrti 
    }


    public void ShowPauseScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        deathtext.text = "Pauza"; // až opravím deathcounter musí se vytvořit nový text
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
