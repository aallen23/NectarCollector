using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{

    public Spawn spawnScript;
    public int prefabLength;

    // Start is called before the first frame update
    void Start()
    {
        prefabLength = spawnScript.prefabLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float SpawnInterval()
    {
        return Random.Range(1, 5);
    }

    public int PrefabIndex()
    {
        return Random.Range(0, prefabLength - 1);
    }


}
