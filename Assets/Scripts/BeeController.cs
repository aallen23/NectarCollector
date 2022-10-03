using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{

    public int flowerScore = 1;
    public int goldScore = 5;

    private Touch theTouch;
    private Vector2 touchStartPos, touchEndPos;

    private Vector3 beePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPos = theTouch.position;
            }

            else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
               // touchEndPos == theTouch.position;
                float y = touchStartPos.y - touchEndPos.y;
            }

            

        }
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
