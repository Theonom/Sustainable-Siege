using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerTrash : MonoBehaviour
{
    public Vector3 trashSpawnAreaMin;
    public Vector3 trashSpawnAreaMax;
    public List<GameObject> trashTemplateList;
    public int spawnInterval;
    public int maxTrash;

    private List<GameObject> trashList;
    private float timer;

    private void Start()
    {
        trashList = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomTrash();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomTrash()
    {
        GenerateTrash(new Vector3(Random.Range(trashSpawnAreaMin.x, trashSpawnAreaMax.x), transform.position.y, Random.Range(trashSpawnAreaMin.z, trashSpawnAreaMax.z)));
    }

    public void GenerateTrash(Vector3 position)
    {
        if (trashList.Count >= maxTrash)
        {
            return;
        }

        if (position.x < trashSpawnAreaMin.x ||
            position.x > trashSpawnAreaMax.x ||
            position.z < trashSpawnAreaMin.z ||
            position.z > trashSpawnAreaMax.z)
        {
            return;
        }

        int randomIndex = Random.Range(0, trashTemplateList.Count);
        GameObject trash = Instantiate(trashTemplateList[randomIndex], new Vector3(position.x, transform.position.y, position.z), Quaternion.identity, transform);
        trashList.Add(trash);
    }
}
