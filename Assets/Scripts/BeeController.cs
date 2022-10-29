using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    private Touch touch;
    public Vector3 targetPos;

    public float screenHeight;

    public float xValue;
    public float zValue;

    private float lerp;

    public int health;

    public int flowerScore = 1;
    public int goldScore = 5;

    public GameObject gm;
    public UIManager UIManager;
    public Spawn Spawn;

    public AudioSource goldAudio;
    public AudioSource collisionAudio;
    public AudioSource chimeAudio;
    public AudioClip gold;
    public AudioClip collision;
    public AudioClip chime;

    public bool end;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        UIManager = gm.GetComponent<UIManager>();
        Spawn = gm.GetComponent<Spawn>();
        //rb = GetComponent<Rigidbody>();
        screenHeight = Screen.height;
        end = false;
        xValue = -5.0f;
        zValue = -1.0f;
        lerp = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        health = StaticGameClass.health;
        if(health == 0)
        {
            end = true;
            StartCoroutine(EndGame());
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

    void OnTriggerEnter(Collider other)
    {

        if (!end)
        {
            if (other.tag == "Flower")
            {
                chimeAudio.PlayOneShot(chime, 0.7f);
                StaticGameClass.IncreaseScore(flowerScore);
                if(other.transform.Find("Pollen") != null)
                {
                    Destroy(other.transform.Find("Pollen").gameObject);
                }
            }

            if (other.tag == "Obstacle")
            {
                collisionAudio.PlayOneShot(collision, 1.5f);
                StaticGameClass.TakeDamage();
                UIManager.UpdateHealth();
            }

            if (other.tag == "GoldFlower")
            {
                goldAudio.PlayOneShot(gold, 0.7f);
                StaticGameClass.IncreaseScore(goldScore);
                if (other.transform.Find("Pollen") != null)
                {
                    Destroy(other.transform.Find("Pollen").gameObject);
                }
                if (other.transform.Find("Particle System") != null)
                {
                    Destroy(other.transform.Find("Particle System").gameObject);
                }
                if (other.transform.Find("Audio Source") != null)
                {
                    Destroy(other.transform.Find("Audio Source").gameObject);
                }
            }
        }

    }

    public void MoveBee(Touch touch)
    {
        if (touch.position.y > (screenHeight / 2))
        {
            if (transform.position.y == -2.5f)
            {
                targetPos = new Vector3(xValue, 1.0f, zValue);
                StartCoroutine(Lerp(transform.position, targetPos));
            }

            else if (transform.position.y == 1.0f)
            {
                targetPos = new Vector3(xValue, 4.5f, zValue);
                StartCoroutine(Lerp(transform.position, targetPos));
            }
        }

        else if (touch.position.y < (screenHeight / 2))
        {
            if (transform.position.y == 1.0f)
            {
                targetPos = new Vector3(xValue, -2.5f, zValue);
                StartCoroutine(Lerp(transform.position, targetPos));
            }

            else if (transform.position.y == 4.5f)
            {
                targetPos = new Vector3(xValue, 1.0f, zValue);
                StartCoroutine(Lerp(transform.position, targetPos));
            }

        }

    }

    public void ResetBee()
    {
        transform.position = new Vector3(-5, 1, -1);
    }

    IEnumerator Lerp(Vector3 startPos, Vector3 targetPos)
    {
        float time = 0;
        while (time < lerp)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, time / lerp);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.2f);
        StaticGameClass.PlayingFalse();
        Spawn.StopSpawning();
        end = false;
        UIManager.DestroyAll();
        UIManager.SetFinalScore();
        UIManager.DisableUI();
        UIManager.EnableEndGame();
    }

}
