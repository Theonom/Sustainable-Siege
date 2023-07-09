using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("Music");
        if (music.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
