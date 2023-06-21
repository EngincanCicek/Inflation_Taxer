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
    public GameObject dustGroundPrefab;  // DustGround prefabini ekleyin
    public GameObject hitEffectPrefab;  // HitEffect prefabini ekleyin
    private float maxPositionFrameVerticle = 9;
    private LevelControllerScript levelControllerScript;


    // Start is called before the first frame update
    void Start()
    {

        InitalizeVariables();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerAlive) {
            Vector3 spawnPosition = transform.position + Vector3.down * (circleCollider.radius / 2);
            rigidbody.velocity = Vector2.up * jumpScale;
            GameObject dustGround = Instantiate(dustGroundPrefab, spawnPosition, Quaternion.identity);
            Destroy(dustGround, 0.3f);


        }
        if (transform.position.y > maxPositionFrameVerticle ||
            transform.position.y < -maxPositionFrameVerticle) {
            startLevelEnd();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPoint = collision.contacts[0].point;
        GameObject hitEffect = Instantiate(hitEffectPrefab, hitPoint, Quaternion.identity);
        Destroy(hitEffect, 0.3f);  

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


    }


}
