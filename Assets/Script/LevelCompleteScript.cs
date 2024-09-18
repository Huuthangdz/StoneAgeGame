using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteScript : MonoBehaviour
{
    [SerializeField] public GameObject LevelComplete;
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        LevelComplete.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelComplete.SetActive(false);
        Time.timeScale = 1;
    }

    public void Next()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            LevelComplete.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log("Comming Soon");
        }
    }
}
