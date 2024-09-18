using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelected : MonoBehaviour
{
    [SerializeField] private GameObject[] skins;
    [SerializeField] private int selectedCharacter;
    [SerializeField] private Selected[] Selected;
    [SerializeField] private Button unlockButton;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI priceText;
    
    void Start()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins) 
            player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        foreach( Selected c in Selected)
        {
            if (c.price == 0)
                c.isUnlock = true;
            else 
            {
                c.isUnlock = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if ( selectedCharacter == skins.Length)
        {
            selectedCharacter = 0;
        }
        skins[selectedCharacter].SetActive(true);
        if (Selected[selectedCharacter].isUnlock)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }
        UpdateUI();

    }
    public void changePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
        {
            selectedCharacter = skins.Length -1;
        }
        skins[selectedCharacter].SetActive(true);
        if (Selected[selectedCharacter].isUnlock)
        {
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        }
        UpdateUI();

    }

    public void UpdateUI()
    {
        unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = Selected[selectedCharacter].price.ToString();
        coinText.text = PlayerPrefs.GetInt("numberOfCoin", 0).ToString();
        if (Selected[selectedCharacter].isUnlock == true)
            unlockButton.gameObject.SetActive(false);
        else 
        {
            if (PlayerPrefs.GetInt("numberOfCoin",0) < Selected[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            } 
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }
    public void Unlock()
    {
        int coin = PlayerPrefs.GetInt("numberOfCoin", 0);
        int price = Selected[selectedCharacter].price;
        PlayerPrefs.SetInt("numberOfCoin", coin - price);
        PlayerPrefs.SetInt(Selected[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        Selected[selectedCharacter].isUnlock = true;
        UpdateUI();
    }
}
