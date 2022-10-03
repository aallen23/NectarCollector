using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject home;
    public GameObject ui;
    public GameObject endGame;

    public TMP_Text score;
    public TMP_Text health;
    public TMP_Text finalScore;

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

    public void EnableHome()
    {
        home.SetActive(true);
    }

    public void DisableHome()
    {
        home.SetActive(false);
    }

    public void EnableUI()
    {
        ui.SetActive(true);
    }

    public void DisableUI()
    {
        ui.SetActive(false);
    }

    public void EnableEndGame()
    {
        endGame.SetActive(true);
    }

    public void DisableEndGame()
    {
        endGame.SetActive(false);
    }

    public void SetFinalScore()
    {
        finalScore.text = "Final Score: " + StaticGameClass.score;
    }
}
