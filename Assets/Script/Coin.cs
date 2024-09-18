using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.numberOfCoin++;
            PlayerPrefs.SetInt("numberOfCoin", PlayerManager.numberOfCoin);
            Destroy(gameObject);
            AudioManager.instance.Play("Coin");
        }
    }
}
