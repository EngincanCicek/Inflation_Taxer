using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour
{
    public LogicMenagerScript menagerScript;
    // Start is called before the first frame update
    void Start()
    {
        menagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==3)
        {
            menagerScript.incraseScore(1);
        }
    }
}
