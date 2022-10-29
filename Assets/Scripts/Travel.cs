using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour
{

    [SerializeField] SpeedTracker speedTracker;

    // Start is called before the first frame update
    void Start()
    {
        speedTracker = GameObject.FindWithTag("GameManager").GetComponent<SpeedTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speedTracker.speed, Camera.main.transform);
    }
}
