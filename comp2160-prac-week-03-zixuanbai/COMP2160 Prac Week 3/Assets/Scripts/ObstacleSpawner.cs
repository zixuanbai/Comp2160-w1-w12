using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Obstacle obstacle;
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float spawnRandomness = 1.0f;
    [SerializeField] private float timer;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.5f;
    [SerializeField] private float minMoveSpeed = 2.0f;
    [SerializeField] private float maxMoveSpeed = 6.0f;
    [SerializeField] private Color[] obstacleColors;

    private void Start()
    {
        timer = Random.Range(spawnInterval - spawnRandomness, spawnInterval + spawnRandomness);
    }

    private void Update()
    {
        if (timer != 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Obstacle newObstacle = Instantiate(obstacle, transform.position,Quaternion.identity ,transform);
            timer = Random.Range(1.0f, 3.0f);
        }
    }
    private void SpawnObstacle()
    {
        Obstacle newObstacle = Instantiate(obstacle, transform.position, Quaternion.identity, transform);

        float randomScale = Random.Range(minScale, maxScale);
        float randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        int randomColorIndex = Random.Range(0, obstacleColors.Length);

        newObstacle.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        newObstacle.MoveSpeed = randomMoveSpeed;
        newObstacle.GetComponent<Renderer>().material.color = obstacleColors[randomColorIndex];
    }
}

    

