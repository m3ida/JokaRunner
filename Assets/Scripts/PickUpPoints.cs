using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public int scoreToGive;
    public int moneyToGive;
    private ScoreManager theScoreManager;

    private AudioSource coinSound;
    
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("coinSound").GetComponent<AudioSource>();
        coinSound.volume = PlayerPrefs.GetFloat("SFXVolume");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") 
        {

            theScoreManager.AddScore(scoreToGive);
            theScoreManager.AddMoney(moneyToGive);
            gameObject.SetActive(false);


            if (coinSound.isPlaying)
            {

                coinSound.Stop();
                coinSound.Play();
            }
            else
            {
                coinSound.Play();
            }
        }
    }
}

