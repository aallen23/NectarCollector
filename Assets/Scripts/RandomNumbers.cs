using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{
 

    public float SpawnInterval()
    {
        return Random.Range(1, 5);
    }

    public int PrefabIndex(int prefabLength)
    {
        return Random.Range(0, prefabLength);
    }


}
