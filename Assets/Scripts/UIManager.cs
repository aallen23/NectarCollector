using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject home;
    public GameObject ui;
    public GameObject endGame;

    public GameObject healthBar;

    public TMP_Text score;
    public TMP_Text finalScore;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + StaticGameClass.score;
    }

    public void UpdateHealth()
    {
        healthBar.transform.GetChild(StaticGameClass.health).gameObject.SetActive(false);
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
