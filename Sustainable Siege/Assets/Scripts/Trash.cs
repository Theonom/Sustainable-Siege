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
                Destroy(gameObject);
                player.GetComponent<PlayerController>().bringTrash = true;

                if (organik == true)
                {
                    gameController.GetComponent<GameController>().trash = "Apel";
                }
                if (kertas == true)
                {
                    gameController.GetComponent<GameController>().trash = "Kardus";
                }
                if (residu == true)
                {
                    gameController.GetComponent<GameController>().trash = "Rokok";
                }
                if (anorganik == true)
                {
                    gameController.GetComponent<GameController>().trash = "Kaleng";
                }
                if (bTiga == true)
                {
                    gameController.GetComponent<GameController>().trash = "Botol Kaca";
                }
            }
        }
    }
}
