using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject home;
    public GameObject ui;
    public GameObject pauseMenu;
    public GameObject beesMenu;
    public GameObject endGame;

    public GameObject bee;
    public BeeController bc;
    public GameObject healthBar;

    public GameObject gm;
    public Spawn spawn;

    public TMP_Text score;
    public TMP_Text finalScore;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        spawn = gm.GetComponent<Spawn>();
        bc = bee.GetComponent<BeeController>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + StaticGameClass.score;
    }

    public void PlayButton()
    {
        home.SetActive(false);
        bee.SetActive(true);
        ui.SetActive(true);
        spawn.StartSpawning();
    }

    public void SaveTheBees()
    {
        home.SetActive(false);
        beesMenu.SetActive(true);
    }

    public void MenuButton()
    {
        bee.SetActive(false);
        endGame.SetActive(false);
        pauseMenu.SetActive(false);
        beesMenu.SetActive(false);
        home.SetActive(true);
        StaticGameClass.ResetHealth();
    }

    public void ResetButton()
    {
        bc.end = false;
        endGame.SetActive(false);
        ResetHealthBar();
        StaticGameClass.ResetHealth();
        StaticGameClass.ResetScore();
        ui.SetActive(true);
        spawn.StartSpawning();
    }

    public void PauseButton()
    {
        bee.SetActive(false);
        ui.SetActive(false);
        pauseMenu.SetActive(true);
        spawn.StopSpawning();
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        ui.SetActive(true);
        bee.SetActive(true);
        spawn.StartSpawning();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetHealthBar()
    {
        for(int i = 0; i < 3; i++)
        {
            healthBar.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void UpdateHealth()
    {
        healthBar.transform.GetChild(StaticGameClass.health).gameObject.SetActive(false);
    }

    public void SetFinalScore()
    {
        finalScore.text = "You collected " + StaticGameClass.score + " flowers for your hive!";
    }

    public void DisableUI()
    {
        ui.SetActive(false);
    }

    public void EnableEndGame()
    {
        endGame.SetActive(true);
    }
}
