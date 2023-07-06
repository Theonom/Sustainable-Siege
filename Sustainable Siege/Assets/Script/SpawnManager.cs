using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 enemySpawnAreaMin;
    public Vector3 enemySpawnAreaMax;
    public GameObject enemyTemplate;
    public int maxEnemy;
    public int spawnInterval;

    private List<GameObject> enemyList;
    private float timer;

    private void Start()
    {
        enemyList = new List<GameObject>();
        timer = 0;

        GenerateRandomEnemy();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawnInterval)
        {
            GenerateRandomEnemy();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomEnemy()
    {
        GenerateEnemy(new Vector3(Random.Range(enemySpawnAreaMin.x, enemySpawnAreaMax.x), transform.position.y, Random.Range(enemySpawnAreaMin.z, enemySpawnAreaMax.z)));
    }

    private void GenerateEnemy(Vector3 position)
    {
        if(enemyList.Count >= maxEnemy)
        {
            return;
        }

        if (position.x < enemySpawnAreaMin.x ||
            position.x > enemySpawnAreaMax.x ||
            position.z < enemySpawnAreaMin.z ||
            position.z > enemySpawnAreaMax.z)
        {
            return;
        }

        GameObject enemy = Instantiate(enemyTemplate, new Vector3(position.x, transform.position.y, position.z), Quaternion.identity);
        enemyList.Add(enemy);
    }
}
