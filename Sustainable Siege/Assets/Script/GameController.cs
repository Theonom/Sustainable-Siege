using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<GameObject> wall;
    public GameObject camEnemy, camPlayer;
    public Slider hpSlider;
    public Text zombieText, sumTrashText, timeText, trasText, gunLevelText, sumBulletText, coinText; 
    public int hpWall, maxHpWall, sumBullet, sumCoin, zombieDead, sumTrash, gunLevel;
    public bool sortTrash;
    public string trash, trashBox;
    public int sumTrashOrganik, sumTrashKertas, sumTrashResidu, sumTrashAnorganik, sumTrashBtiga;

    private GameObject player;
    private bool cameraEnemy;
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraEnemy = false;
        hpWall = maxHpWall;
        timer = 0;
        gunLevel = 1;
        sumBullet = 2;
    }

    private void Update()
    {
        Wall();
        BulletAndCoin();
        Information();
        SetHelthWall();

        if (hpWall >= maxHpWall)
        {
            hpWall = maxHpWall;
        }

        if (timer >= 0)
        {
            timer += Time.deltaTime;
            DisplayTime(timer);
        }
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

            if (trash == "Apel" && trashBox == "Organik")
            {
                trash = "";
                hpWall += 10;
                sumTrashOrganik += 1;
                sumTrash += 1;
            }
            else if (trash == "Kardus" && trashBox == "Kertas")
            {
                trash = "";
                hpWall += 10;
                sumTrashKertas += 1;
                sumTrash += 1;
            }
            else if (trash == "Rokok" && trashBox == "Residu")
            {
                trash = "";
                hpWall += 10;
                sumTrashResidu += 1;
                sumTrash += 1;
            }
            else if (trash == "Kaleng" && trashBox == "Anorganik")
            {
                trash = "";
                hpWall += 10;
                sumTrashAnorganik += 1;
                sumTrash += 1;
            }
            else if (trash == "Botol Kaca" && trashBox == "B3")
            {
                trash = "";
                hpWall += 10;
                sumTrashBtiga += 1;
                sumTrash += 1;
            }
            else
            {
                trash = "";
            }
        }
    }

    public void Upgrade()
    {
        if (sumCoin >= 15)
        {
            gunLevel += 1;
            sumCoin -= 15;
            player.GetComponent<PlayerController>().bulletDamage += 5;
        }
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

    public void BulletAndCoin()
    {
        if (sumTrashOrganik >= 2)
        {
            sumBullet += 1;
            sumCoin += 1;
            sumTrashOrganik -= 3;
        }
        if (sumTrashAnorganik >= 2)
        {
            sumBullet += 1;
            sumCoin += 2;
            sumTrashAnorganik -= 4;
        }
        if (sumTrashResidu >= 3)
        {
            sumBullet += 1;
            sumCoin += 2;
            sumTrashResidu -= 4;
        }
        if (sumTrashKertas >= 3)
        {
            sumBullet += 1;
            sumCoin += 3;
            sumTrashKertas -= 5;
        }
        if (sumTrashBtiga >= 3)
        {
            sumBullet += 1;
            sumCoin += 3;
            sumTrashBtiga -= 5;
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void SetHelthWall()
    {
        hpSlider.maxValue = maxHpWall;
        hpSlider.value = hpWall;
    }

    public void Information()
    {
        zombieText.text = zombieDead.ToString();
        sumTrashText.text = sumTrash.ToString();
        trasText.text = trash;
        gunLevelText.text = gunLevel.ToString();
        sumBulletText.text = sumBullet.ToString();
        coinText.text = sumCoin.ToString();
    }
}
