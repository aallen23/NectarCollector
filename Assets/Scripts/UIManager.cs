using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text score;
    public TMP_Text health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + StaticGameClass.health;
        score.text = "Score: " + StaticGameClass.score;
    }

}
