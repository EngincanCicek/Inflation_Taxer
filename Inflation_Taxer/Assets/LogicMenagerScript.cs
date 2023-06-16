using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicMenagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    // Start is called before the first frame updateg 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("add score")]
    public void OnBecameInvisible()
    {
        playerScore++;
        scoreText.text=playerScore.ToString();
    }

}
