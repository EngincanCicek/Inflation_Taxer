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
    private LevelControllerScript levelControllerScript;
    private float dollarValue;
    private float dollarDecreasingAmount;


    // Start is called before the first frame updateg 
    void Start()
    {
        InitalizeVariables();
    }


    [ContextMenu("add score")]
    public void incraseScore(int i)
    {
        playerScore+= i;
        scoreText.text=playerScore.ToString();
        dollarValue = RoundToNearest(dollarValue - dollarDecreasingAmount, 0.1f); // text can't be 0.99998 like number

        Debug.Log("DOLLARVALUE: "+dollarValue);
        Debug.Log("TMP: " + scoreTextTMPro.text);


        scoreTextTMPro.text= dollarValue.ToString() + "<sprite index=0>";


    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    [ContextMenu("gameOVer")]
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void InitalizeVariables()
    {
        levelControllerScript = new LevelControllerScript();
        dollarValue = levelControllerScript.HowMuchOneDollar();
        dollarDecreasingAmount = levelControllerScript.HowMuchDollarsDeclineAmount();

        Debug.Log("DOLLARVALUE1: " + dollarValue);

    }
    private float RoundToNearest(float number, float toNearest)
    {
        return Mathf.Round(number / toNearest) * toNearest;
    }


}
