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
    public GameObject creditsMenu;
    public GameObject endGame;

    public GameObject bee;
    public BeeController bc;
    public GameObject healthBar;

    public GameObject gm;
    public Spawn spawn;
    public float delay;
    public SpeedTracker speedTracker;
    public GameObject spawnHolder;

    public TMP_Text score;
    public TMP_Text finalScore;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameManager");
        speedTracker = gm.GetComponent<SpeedTracker>();
        spawn = gm.GetComponent<Spawn>();
        bc = bee.GetComponent<BeeController>();
        delay = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + StaticGameClass.score;
    }

    public void PlayButton()
    {
        StartCoroutine(PlaySequence());
    }

    public void SaveTheBees()
    {
        StartCoroutine(BeeSequence());
    }

    public void CreditsButton()
    {
        StartCoroutine(CreditsSequence());
    }

    public void MenuButton()
    {
        StartCoroutine(MenuSequence());
    }

    public void ReplayButton()
    {
        StartCoroutine(ReplaySequence());
    }

    public void PauseButton()
    {
        StartCoroutine(PauseSequence());
    }

    public void ResumeButton()
    {
        StartCoroutine(ResumeSequence());
    }

    public void Quit()
    {
        StartCoroutine(QuitSequence());
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(delay);
        StaticGameClass.PlayingTrue();
        home.SetActive(false);
        bee.SetActive(true);
        ui.SetActive(true);
        spawnHolder.SetActive(true);
        speedTracker.Activate();
        spawn.StartSpawning();
    }

    IEnumerator BeeSequence()
    {
        yield return new WaitForSeconds(delay);
        home.SetActive(false);
        beesMenu.SetActive(true);
    }

    IEnumerator CreditsSequence()
    {
        yield return new WaitForSeconds(delay);
        home.SetActive(false);
        creditsMenu.SetActive(true);
    }

    IEnumerator MenuSequence()
    {
        yield return new WaitForSeconds(delay);
        StaticGameClass.PlayingFalse();
        StaticGameClass.ResetHealth();
        StaticGameClass.ResetScore();
        DestroyAll();
        ResetHealthBar();
        speedTracker.Deactivate();
        speedTracker.ResetSpeed();
        bee.SetActive(false);
        endGame.SetActive(false);
        pauseMenu.SetActive(false);
        beesMenu.SetActive(false);
        creditsMenu.SetActive(false);
        home.SetActive(true);
    }

    IEnumerator PauseSequence()
    {
        yield return new WaitForSeconds(delay);
        StaticGameClass.PlayingFalse();
        spawnHolder.SetActive(false);
        speedTracker.Deactivate();
        spawn.StopSpawning();
        bee.SetActive(false);
        ui.SetActive(false);
        pauseMenu.SetActive(true);
    }

    IEnumerator ResumeSequence()
    {
        yield return new WaitForSeconds(delay);
        StaticGameClass.PlayingTrue();
        pauseMenu.SetActive(false);
        spawnHolder.SetActive(true);
        ui.SetActive(true);
        bee.SetActive(true);
        speedTracker.Activate();
        spawn.StartSpawning();
    }

    IEnumerator ReplaySequence()
    {
        yield return new WaitForSeconds(delay);
        StaticGameClass.PlayingTrue();
        StaticGameClass.ResetHealth();
        StaticGameClass.ResetScore();
        DestroyAll();
        ResetHealthBar();
        speedTracker.ResetSpeed();
        bc.end = false;
        endGame.SetActive(false);
        bee.SetActive(true);
        ui.SetActive(true);
        speedTracker.Activate();
        spawn.StartSpawning();
    }

    IEnumerator QuitSequence()
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

    public void ResetHealthBar()
    {
        for(int i = 0; i < 3; i++)
        {
            healthBar.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void DestroyAll()
    {
        for(int i = 0; i < spawnHolder.transform.childCount; i++)
        {
            Destroy(spawnHolder.transform.GetChild(i).gameObject);
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
        bee.SetActive(false);
        endGame.SetActive(true);
    }
}
