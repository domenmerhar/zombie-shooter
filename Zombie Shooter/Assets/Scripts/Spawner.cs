using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnArea;

    [Header("Enemies")]
    [SerializeField] private GameObject zombiePrefab;

    Bounds bounds;

    float spawnCooldown = 1f;
    float spawnTimer = 1f;

    private void Awake()
    {
        bounds = spawnArea.bounds;   
    }

    private void FixedUpdate()
    {
        if (spawnTimer >= spawnCooldown)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.max.y, bounds.min.y);

        Instantiate(zombiePrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }
}
