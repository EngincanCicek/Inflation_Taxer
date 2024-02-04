using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LevelControllerScript;

public class emotions_script : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;
    public float jumpScale;
    public LogicMenagerScript menagerScript;
    public bool playerAlive = true;
    public CircleCollider2D circleCollider;
    public GameObject dustGroundPrefab;  
    public GameObject hitEffectPrefab;
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioSource audioSource;
    public GameObject menuText;
    private bool isGameResume = true;
    private float maxPositionFrameVerticle = 9;
    private LevelControllerScript levelControllerScript;
    private bool isItFirstHit = true;


    // Start is called before the first frame update
    void Start()
    {

        InitalizeVariables();
    }

    // Update is called once per frame
    void Update()
    {

        

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && playerAlive && isGameResume) {
            Vector3 spawnPosition = transform.position + Vector3.down * (circleCollider.radius / 2);
            rigidbody.velocity = Vector2.up * jumpScale;
            GameObject dustGround = Instantiate(dustGroundPrefab, spawnPosition, Quaternion.identity);
            Destroy(dustGround, 0.3f);

            audioSource.PlayOneShot(jumpSound);  



        }
        else if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && !isGameResume)
        {
            ResumeGame();
        }
        else if (menagerScript.gameIsOver && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            menagerScript.restartGame();
        }
        else if (Input.GetKeyDown(KeyCode.F1)) // Down there CHEAT KEYS will be function, looks bad
        {
            LevelControllerScript.levelCounter = 1;
            menagerScript.restartGame();

        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            LevelControllerScript.levelCounter = 2;
            menagerScript.restartGame();

        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            LevelControllerScript.levelCounter = 3;
            menagerScript.restartGame();

        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            LevelControllerScript.levelCounter = 4;
            menagerScript.restartGame();

        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            LevelControllerScript.levelCounter = 5;
            menagerScript.restartGame();

        }else if (Input.GetKeyDown(KeyCode.F12) || Input.touchCount == 3) // ending score cheat
        {
            menagerScript.ChangeDollarValueForCheat();
        }

        if (transform.position.y > maxPositionFrameVerticle ||
            transform.position.y < -maxPositionFrameVerticle) {
            startLevelEnd();
        }

         if (Input.GetKeyDown(KeyCode.Escape) && playerAlive){
            if (isGameResume)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();

            }

        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPoint = collision.contacts[0].point;
        GameObject hitEffect = Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);
        Destroy(hitEffect, 0.3f);

        if (isItFirstHit)
        {
            audioSource.PlayOneShot(hitSound);
            isItFirstHit =false;
        }


        startLevelEnd();
    }

    private void startLevelEnd()
    {
        menagerScript.gameOver();
        playerAlive = false;
    }

    private void InitalizeVariables()
    {
        menagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicMenagerScript>();
        levelControllerScript = new LevelControllerScript();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(levelControllerScript.ChangePlayersSprite());
        gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);


        if (circleCollider != null)
        {
            Coordinates coordinates = levelControllerScript.GetCoordinateFromLevel();
            circleCollider.offset = new Vector2(coordinates.X, coordinates.Y); // Koordinat

            Debug.Log("COORDINATES: "+ coordinates.X+"  "+coordinates.Y+"   "+coordinates.R);

            // Yarýçapý ayarla
            circleCollider.radius = coordinates.R; // Radius 
        }

        PauseGame();


    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        isGameResume = false;
        menagerScript.GamePaused(); ;
   
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isGameResume = true;
        menagerScript.GameRunning();
    }


}
