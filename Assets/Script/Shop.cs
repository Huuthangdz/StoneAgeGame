using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public void Shoping()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
