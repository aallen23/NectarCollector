using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] collisionPrefabs;
    [SerializeField] GameObject spawnHolder;

    [SerializeField] GameObject[] obstaclesInScene;
    public int obstacleCount;
    public int obstacleCap;

    [SerializeField] int index;

    [SerializeField] float spawnPosX = 15.0f;
    [SerializeField] float spawnPosZ = 0.0f;
    [SerializeField] Vector3 spawnPos1, spawnPos2, spawnPos3;

    public bool spawn = false;

    public RandomNumbers ranNum;

    // Start is called before the first frame update
    void Start()
    {
        obstacleCap = 5;

        spawnPos1 = new Vector3(spawnPosX, 4.5f, spawnPosZ);
        spawnPos2 = new Vector3(spawnPosX, 1.0f, spawnPosZ);
        spawnPos3 = new Vector3(spawnPosX, -2.5f, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        obstaclesInScene = GameObject.FindGameObjectsWithTag("Obstacle");
        obstacleCount = obstaclesInScene.Length;
    }

    public void StartSpawning()
    {
        spawn = true;
        if (spawn)
        {
            StartCoroutine(SpawnIn(spawnPos1));
            StartCoroutine(SpawnIn(spawnPos2));
            StartCoroutine(SpawnIn(spawnPos3));
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    IEnumerator SpawnIn(Vector3 spawnPos)
    {

        if(StaticGameClass.playing == true)
        {
            while (spawn)
            {
                if (obstacleCount < obstacleCap)
                {
                    index = ranNum.PrefabIndex(10);
                }

                else if (obstacleCount >= obstacleCap)
                {
                    index = ranNum.PrefabIndex(6);
                }

                Instantiate(collisionPrefabs[index], spawnPos, collisionPrefabs[index].transform.rotation, spawnHolder.transform);

                yield return new WaitForSeconds(ranNum.SpawnInterval());
            }
        }

    }



}
