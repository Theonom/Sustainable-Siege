using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject soundOn, soundOff, music;
    public bool sound;

    private void Start()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        music.SetActive(true);
        sound = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(music);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Sound()
    {
        if (sound == true)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            music.SetActive(false);
            sound = false;
        }
        else
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            music.SetActive(true);
            sound = true;
        }
    }
}
