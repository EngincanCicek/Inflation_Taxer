using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;
using TMPro;

public class LogicMenagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public TextMeshProUGUI scoreTextTMPro;
    public GameObject gameOverScreen;
    public Text gameOverText;
    public Text popupText;
    public MusicAndSoundScript soundNMusic;
    public GameObject canvaEnding;
    public GameObject canva;
    public GameObject wallSpawner;
    private LevelControllerScript levelControllerScript;
    private float dollarValue;
    private float dollarDecreasingAmount;
    public bool gameIsOver { get; set; }

    // Start is called before the first frame updateg 
    void Start()
    {
        InitalizeVariables();
        ChangePopUpText();

    }


    [ContextMenu("add score")]
    public void incraseScore(int i)
    {
        playerScore+= i;
        scoreText.text=playerScore.ToString();
        dollarValue = RoundToNearest(dollarValue - dollarDecreasingAmount, 0.1f); // text can't be 0.99998 like number

        Debug.Log("DOLLARVALUE: "+dollarValue);
        Debug.Log("TMP: " + scoreTextTMPro.text);


        ScoreTextEditerBananaTMP();
        IsNextLevel();


    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    [ContextMenu("gameOVer")]
    public void gameOver()
    {
        
            gameOverText.text = "GAME OVER";

            soundNMusic.MakeVisibleButton(true);
            gameOverScreen.SetActive(true);
            gameIsOver = true;
        

    }

    [ContextMenu("gamePause")]
    public void GamePaused()
    {
        gameOverText.text = "GAME PAUSED";
        soundNMusic.MakeVisibleButton(true);
        gameOverScreen.SetActive(true);
        ChangePopUpText();

    }

    [ContextMenu("gameContiune")]
    public void GameRunning()
    {
        soundNMusic.MakeVisibleButton(false);
        gameOverScreen.SetActive(false);

    }

    private void InitalizeVariables()
    {
        levelControllerScript = new LevelControllerScript();
        dollarValue = levelControllerScript.HowMuchOneDollar();
        dollarDecreasingAmount = levelControllerScript.HowMuchDollarsDeclineAmount();

        ScoreTextEditerBananaTMP();
        Debug.Log("DOLLARVALUE1: " + dollarValue);

    }
    private float RoundToNearest(float number, float toNearest)
    {
        return Mathf.Round(number / toNearest) * toNearest;
    }

    private void IsNextLevel()
    {
        if (dollarValue <= levelControllerScript.GiveMinDollarValueForLevel()) { // Current Level ended
            if (LevelControllerScript.levelCounter == LevelControllerScript.maxLevel)
            {
                canvaEnding.SetActive(true);
                canva.SetActive(false);
                wallSpawner.SetActive(false);


            }
            else
            {
                LevelControllerScript.levelCounter += 1;
                restartGame();
            }


        }
    }

    private void ScoreTextEditerBananaTMP()
    {
        scoreTextTMPro.text = dollarValue.ToString() + "<sprite index=0>";

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ChangePopUpText()
    {
        popupText.text = "You have to make dollars " + levelControllerScript.GiveMinDollarValueForLevel()+ " Banana";
    }

    public void ChangeDollarValueForCheat()
    {
        dollarValue = 0;
    }
}
