using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;

    private PowerUpManager thePowerupManager;

    public Sprite[] powerupSprites;

    public float powerUpLenght;

    // Start is called before the first frame update
    void Start()
    {
        thePowerupManager = FindObjectOfType<PowerUpManager>();

    }

    void Awake()
    {
        int powerupSelector = Random.Range(0, 2);


        switch(powerupSelector)
        {
            case 0: doublePoints = true;
                break;

            case 1: safeMode = true;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];  

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            if (thePowerupManager.powerupActive)
            {
                thePowerupManager.powerupLenghtCounter += powerUpLenght;
            }
            else
            {
                thePowerupManager.ActivatePowerup(doublePoints, safeMode, powerUpLenght);
            }
        }
        
        gameObject.SetActive(false);
    }

}
