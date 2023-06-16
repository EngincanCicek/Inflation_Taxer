using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject Wall;
    public float spawnRate = 3;
    public float heightCalculator = 7;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnWall();
            timer -= spawnRate;
        }
    }

    private void SpawnWall()
    {
        float lowerPosition = transform.position.y - heightCalculator;
        float upperPosition = transform.position.y + heightCalculator;
        Instantiate(Wall, new Vector3(transform.position.x, Random.Range(lowerPosition, upperPosition), 0), transform.rotation);
    }
}
