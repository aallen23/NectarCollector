using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] collisionPrefabs;

    //[SerializeField] float startDelay = 2;

    public int prefabLength;

    [SerializeField] int index;

    [SerializeField] float spawnPosX;
    [SerializeField] float spawnPosZ;
    [SerializeField] Vector3 spawnPos1, spawnPos2, spawnPos3;

    public bool spawn = false;

    public RandomNumbers ranNum;

    // Start is called before the first frame update
    void Start()
    {
        prefabLength = collisionPrefabs.Length;

        spawnPos1 = new Vector3(spawnPosX, 1.0f, spawnPosZ);
        spawnPos2 = new Vector3(spawnPosX, 1.0f, spawnPosZ);
        spawnPos3 = new Vector3(spawnPosX, 1.0f, spawnPosZ);
    }

    public void StartSpawning()
    {
        spawn = true;
        StartCoroutine(SpawnIn(spawnPos1));
        StartCoroutine(SpawnIn(spawnPos2));
        StartCoroutine(SpawnIn(spawnPos3));
    }


    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SpawnIn(Vector3 spawnPos)
    {
        if (spawn)
        {
            index = ranNum.PrefabIndex();

            Instantiate(collisionPrefabs[index], spawnPos, collisionPrefabs[index].transform.rotation);
        }

        yield return new WaitForSeconds(ranNum.SpawnInterval());
    }



}
