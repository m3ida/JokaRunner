using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource MainMenuMusic;

    private GameManager theGameManager;

    public Slider musicSlider;

    public Slider SFXSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    private void Update()
    {

    }


    public void ChangeMusicVolume()
    {
        MainMenuMusic.volume = musicSlider.value;
        //theGameManager.ElevatorMusic.volume = musicSlider.value;
        //theGameManager.EndlessAudio.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void ChangeSFXVolume()
    {
        //theGameManager.coinSound.volume = SFXSlider.value;
        //theGameManager.deathSound.volume = SFXSlider.value;
        //theGameManager.jumpSound.volume = SFXSlider.value;
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
}
