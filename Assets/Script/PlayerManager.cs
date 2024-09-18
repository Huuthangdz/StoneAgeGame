using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoin;

    public static int numberOfCoin;
    public GameObject[] playerPrefabs;

    private int characterIndex;
    private void Awake()
    {

        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPrefabs[characterIndex]);
        numberOfCoin = PlayerPrefs.GetInt("numberOfCoin", 0);

    }
    private void Update()
    {
        textCoin.text = numberOfCoin.ToString();
    }
}
