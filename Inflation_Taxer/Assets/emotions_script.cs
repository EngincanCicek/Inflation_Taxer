using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotions_script : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float jumpScale;
    public LogicMenagerScript menagerScript;
    public bool playerAlive = true;
    private float maxPositionFrameVerticle = 8.5f;

    // Start is called before the first frame update
    void Start()
    {
        menagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerAlive) {
            rigidbody.velocity = Vector2.up * jumpScale;

        }
        if (transform.position.y > maxPositionFrameVerticle ||
            transform.position.y < -maxPositionFrameVerticle) {
            startLevelEnd();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        startLevelEnd();
    }

    private void startLevelEnd()
    {
        menagerScript.gameOver();
        playerAlive = false;
    }

}
