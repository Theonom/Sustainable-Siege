using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> wall;
    public GameObject camEnemy, camPlayer;
    public int hpWall;
    public bool sortTrash;
    public string trash, trashBox;

    private GameObject player;
    private bool cameraEnemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraEnemy = false;
    }

    private void Update()
    {
        Wall();
    }

    private void FixedUpdate()
    {
        sortTrash = false;
        trashBox = "";
    }

    public void Wall()
    {
        if(hpWall <= 0)
        {
            for(int i = 0; i < wall.Count; i++)
            {
                wall[i].SetActive(false);
            }
        }
    }

    public void SortTrash()
    {
        if (sortTrash == true)
        {
            player.GetComponent<PlayerController>().bringTrash = false;

            if (trash == "Organik" && trashBox == "Organik")
            {
                trash = "";
                Debug.Log("Tambah Organik");
            }
            else if (trash == "Kertas" && trashBox == "Kertas")
            {
                trash = "";
                Debug.Log("Tambah Kertas");
            }
            else if (trash == "Residu" && trashBox == "Residu")
            {
                trash = "";
                Debug.Log("Tambah Residu");
            }
            else if (trash == "Anorganik" && trashBox == "Anorganik")
            {
                trash = "";
                Debug.Log("Tambah Anorganik");
            }
            else if (trash == "B3" && trashBox == "B3")
            {
                trash = "";
                Debug.Log("Tambah B3");
            }
            else
            {
                trash = "";
            }
        }
    }

    public void Upgrade()
    {
        //upgrade senjata
    }

    public void ChangeCamera()
    {
        if (cameraEnemy == false)
        {
            camPlayer.SetActive(false);
            camEnemy.SetActive(true);
            cameraEnemy = true;
        }
        else
        {
            camPlayer.SetActive(true);
            camEnemy.SetActive(false);
            cameraEnemy = false;
        }
    }
}
