using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class LogicMenagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    // Start is called before the first frame updateg 


    [ContextMenu("add score")]
    public void incraseScore(int i)
    {
        playerScore+= i;
        scoreText.text=playerScore.ToString();

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

}
