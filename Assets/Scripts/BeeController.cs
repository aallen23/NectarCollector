using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{

    public int flowerScore = 1;
    public int goldScore = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");

        if(other.tag == "Flower")
        {
            StaticGameClass.IncreaseScore(flowerScore);
        }

        if(other.tag == "Obstacle")
        {
            StaticGameClass.TakeDamage();
        }

        if(other.tag == "GoldFlower")
        {
            StaticGameClass.IncreaseScore(goldScore);
        }
    }

}
