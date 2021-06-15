using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;

    public AudioSource MusicaInicio;

    public GameObject MenuSettings;

    public GameObject MenuMain;

    private SoundManager theSoundManager;

    public GameObject Shop;

    public GameObject InfoMenu;



    public void ShowInfo()
    {
        InfoMenu.SetActive(true);
        MenuMain.SetActive(false);
    }

    public void Back()
    {
        MenuMain.SetActive(true);
        InfoMenu.SetActive(false);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        MenuMain.SetActive(false);
        MenuSettings.SetActive(true);

    }

    public void BackButton()
    {
        MenuMain.SetActive(true);
        MenuSettings.SetActive(false);

    }

    public void ShopButton()
    {
        MenuMain.SetActive(false);
        Shop.SetActive(true);

    }

    public void ShopBackButton()
    {
        MenuMain.SetActive(true);
        Shop.SetActive(false);

    }
}
