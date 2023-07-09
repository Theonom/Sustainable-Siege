using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionController : MonoBehaviour
{
    public GameObject music;

    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("Music");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
        Destroy(music);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
