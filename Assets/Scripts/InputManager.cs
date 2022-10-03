using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private Touch theTouch;
    private Vector2 touchPos;

    private GameObject bee;
    private Vector3 beePos;
    private Vector3 targetPos;

    private Rigidbody rb;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        bee = GameObject.FindWithTag("Bee");
        rb = bee.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        beePos = bee.transform.position;

        if (Input.touchCount > 0)
        {
            
            theTouch = Input.GetTouch(0);

            if (theTouch.position.y > bee.transform.position.y)
            {
                if (bee.transform.position.y == -2.5f)
                {
                    Debug.Log("move up");
                    Vector3 targotPos = new Vector3(theTouch.position.x, theTouch.position.y, bee.transform.position.z);
                    targotPos = targetPos * Time.deltaTime * speed;
                    rb.MovePosition(transform.position + targetPos);
                    //move bee up to 1.0f
                }

                else if (bee.transform.position.y == 1.0f)
                {
                    Debug.Log("move up");
                    Vector3 targotPos = new Vector3(theTouch.position.x, theTouch.position.y, bee.transform.position.z);
                    targotPos = targetPos * Time.deltaTime * speed;
                    rb.MovePosition(transform.position + targetPos);
                    //move bee up to 4.5f
                }
            }

            else if (theTouch.position.y < bee.transform.position.y)
            {
                if (bee.transform.position.y == 1.0f)
                {
                    Debug.Log("move down");
                    //move bee down to -2.5f
                }

                else if (bee.transform.position.y == 4.5f)
                {
                    Debug.Log("move down");
                    //move bee down to 1.0f
                }
            }

        }
    }
}
