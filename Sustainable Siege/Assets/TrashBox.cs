using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public bool trashBoxOrganik, trashBoxKertas, trashBoxResidu, trashBoxAnorganik, trashBoxBtiga;

    public GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.GetComponent<GameController>().sortTrash = true;

            if (trashBoxOrganik == true)
            {
                gameController.GetComponent<GameController>().trashBox = "Organik";
            }
            if (trashBoxKertas == true)
            {
                gameController.GetComponent<GameController>().trashBox = "Kertas";
            }
            if (trashBoxResidu == true)
            {
                gameController.GetComponent<GameController>().trashBox = "Residu";
            }
            if (trashBoxAnorganik == true)
            {
                gameController.GetComponent<GameController>().trashBox = "Anorganik";
            }
            if (trashBoxBtiga == true)
            {
                gameController.GetComponent<GameController>().trashBox = "B3";
            }
        }
    }
}
