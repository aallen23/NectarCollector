using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTracker : MonoBehaviour
{

    public float speed;
    [SerializeField] float delay;
    [SerializeField] bool activated;

    // Start is called before the first frame update
    void Start()
    {
        delay = 5.0f;
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        activated = true;
        StartCoroutine(IncreaseSpeed());
    }

    public void Deactivate()
    {
        activated = false;
    }

    IEnumerator IncreaseSpeed()
    {
        while(activated == true)
        {
            if (StaticGameClass.playing == true)
            {
                speed += 0.1f;
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public void ResetSpeed()
    {
        speed = 5.0f;
    }

}
