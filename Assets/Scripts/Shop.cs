using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    private int choosenCharacter;

    public GameObject DogCheck;
    public GameObject CatCheck;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("ChoosenChar"))
        {
            choosenCharacter=PlayerPrefs.GetInt("ChoosenChar");
        }
        else
        {
            choosenCharacter = 0;
        }

        if(choosenCharacter == 0)
        {
            DogCheck.SetActive(true);
            CatCheck.SetActive(false);
        } 
        else
        {
            CatCheck.SetActive(true);
            DogCheck.SetActive(false);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectDog()
    {
        if (!DogCheck.activeSelf)
        {
            DogCheck.SetActive(true);
            CatCheck.SetActive(false);
        } 
        choosenCharacter = 0;
        PlayerPrefs.SetInt("ChoosenChar", choosenCharacter);

    }

    public void SelectCat()
    {
        if (!CatCheck.activeSelf)
        {
            CatCheck.SetActive(true);
            DogCheck.SetActive(false);
        }
        choosenCharacter = 1;
        PlayerPrefs.SetInt("ChoosenChar", choosenCharacter);
    }

}
    