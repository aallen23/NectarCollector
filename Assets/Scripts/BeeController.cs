using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    private Touch touch;
    public Vector3 targetPos;

    private Rigidbody rb;

    public float screenHeight;

    public float speed = 2.0f;

    public int health;

    public int flowerScore = 1;
    public int goldScore = 5;

    public GameObject gm;
    public UIManager UIManager;
    public Spawn Spawn;

    public bool end;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        UIManager = gm.GetComponent<UIManager>();
        Spawn = gm.GetComponent<Spawn>();
        rb = GetComponent<Rigidbody>();
        screenHeight = Screen.height;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        health = StaticGameClass.health;
        if(health == 0)
        {
            end = true;
            EndGame();
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Ended)
            {
                MoveBee(touch);
            }
        }
    }

    void FixedUpdate()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");

        if (!end)
        {
            if (other.tag == "Flower")
            {
                StaticGameClass.IncreaseScore(flowerScore);
            }

            if (other.tag == "Obstacle")
            {
                StaticGameClass.TakeDamage();
            }

            if (other.tag == "GoldFlower")
            {
                StaticGameClass.IncreaseScore(goldScore);
            }
        }

        Destroy(other.gameObject);
    }

    public void MoveBee(Touch touch)
    {
        if (touch.position.y > (screenHeight / 2))
        {
            if (transform.position.y == -2.5f)
            {
                Debug.Log("move up");
                targetPos = new Vector3(transform.position.x, 1.0f, transform.position.z);
                rb.MovePosition(targetPos);
                //move bee up to 1.0f
            }

            else if (transform.position.y == 1.0f)
            {
                Debug.Log("move up");
                targetPos = new Vector3(transform.position.x, 4.5f, transform.position.z);
                rb.MovePosition(targetPos);
                //move bee up to 4.5f
            }
        }

        else if (touch.position.y < (screenHeight / 2))
        {
            if (transform.position.y == 1.0f)
            {
                Debug.Log("move down");
                targetPos = new Vector3(transform.position.x, -2.5f, transform.position.z);
                rb.MovePosition(targetPos);
                //move bee down to -2.5f
            }

            else if (transform.position.y == 4.5f)
            {
                Debug.Log("move down");
                targetPos = new Vector3(transform.position.x, 1.0f, transform.position.z);
                rb.MovePosition(targetPos);
                //move bee down to 1.0f
            }

        }

    }

    public void EndGame()
    {
        Spawn.StopSpawning();
        UIManager.SetFinalScore();
        UIManager.DisableUI();
        UIManager.EnableEndGame();
    }

}
