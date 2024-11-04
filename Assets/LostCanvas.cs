using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostCanvas : MonoBehaviour
{
    [SerializeField] private GameObject lostCanvasUI;
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        lostCanvasUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        lostCanvasUI.SetActive(false);
        Time.timeScale = 1;
    }

}
