using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerControler thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;
    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

    public AudioSource EndlessAudio;
    /*public AudioSource jumpSound;
    public AudioSource coinSound;
    public AudioSource deathSound;*/
    public AudioSource ElevatorMusic;


    public bool powerupReset;
    private GameObject players;
    private int choosenChar;

    private GameObject theCat;
    private GameObject theDog;

    public GameObject PauseButton;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();


        EndlessAudio.volume = PlayerPrefs.GetFloat("MusicVolume");
        ElevatorMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        /*jumpSound.volume = PlayerPrefs.GetFloat("SFXVolume");
        coinSound.volume = PlayerPrefs.GetFloat("SFXVolume");
        deathSound.volume = PlayerPrefs.GetFloat("SFXVolume");*/
        players = GameObject.FindWithTag("Player");


        theCat = GameObject.Find("Cat");
        theDog = GameObject.Find("Dog");

        if (PlayerPrefs.HasKey("ChoosenChar"))
        {
            choosenChar = PlayerPrefs.GetInt("ChoosenChar");
        }
        else
        {
            choosenChar = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        players.gameObject.SetActive(false);
        EndlessAudio.Stop();
        powerupReset = true;
        PauseButton.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        players.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        //thePlayer.gameObject.SetActive(true);  retirado senao cria 2 players no inicio da cena
        if (choosenChar == 0)
        {
            theCat.SetActive(false);
            theDog.SetActive(true);
        }
        else
        {
            theDog.SetActive(false);
            theCat.SetActive(true);
        }
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
        powerupReset = true;
        PauseButton.SetActive(true);
        EndlessAudio.Play();
    }



    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }


        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }
    */
}
