using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicMenagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    // Start is called before the first frame updateg 


    [ContextMenu("add score")]
    public void incraseScore()
    {
        playerScore++;
        scoreText.text=playerScore.ToString();
    }

}
