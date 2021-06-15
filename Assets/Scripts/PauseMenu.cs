using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;

    public GameObject pauseMenu;

    public AudioSource EndlessAudio;

    public AudioSource ElevatorMusic;

    public GameObject PauseButton;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        EndlessAudio.Pause();
        ElevatorMusic.Play();
        PauseButton.SetActive(false);
        pauseMenu.SetActive(true);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        ElevatorMusic.Stop();
        EndlessAudio.UnPause();
        pauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ElevatorMusic.Stop();
        PauseButton.SetActive(true);
        FindObjectOfType<GameManager>().Reset();

    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
    }
}
