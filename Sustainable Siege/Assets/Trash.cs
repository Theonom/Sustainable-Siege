using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public bool organik, kertas, residu, anorganik, bTiga;

    private GameObject player, gameController;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<PlayerController>().bringTrash == false)
        {
            if (other.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                player.GetComponent<PlayerController>().bringTrash = true;

                if (organik == true)
                {
                    gameController.GetComponent<GameController>().trash = "Organik";
                }
                if (kertas == true)
                {
                    gameController.GetComponent<GameController>().trash = "Kertas";
                }
                if (residu == true)
                {
                    gameController.GetComponent<GameController>().trash = "Residu";
                }
                if (anorganik == true)
                {
                    gameController.GetComponent<GameController>().trash = "Anorganik";
                }
                if (bTiga == true)
                {
                    gameController.GetComponent<GameController>().trash = "B3";
                }
            }
        }
    }
}
