using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (player.GetComponent<PlayerController>().bringTrash == false)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                player.GetComponent<PlayerController>().bringTrash = true;
            }
        }
    }
}
