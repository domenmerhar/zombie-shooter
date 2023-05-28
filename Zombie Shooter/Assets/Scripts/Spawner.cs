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

    // Reference to the player's camera
    private Camera playerCamera;

    private void Awake()
    {
        bounds = spawnArea.bounds;
        playerCamera = Camera.main; // Assuming the player's camera is tagged as "MainCamera"
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
        float x, y;
        bool isOnScreen;

        // Keep generating random positions until an off-screen position is found
        do
        {
            x = Random.Range(bounds.min.x, bounds.max.x);
            y = Random.Range(bounds.max.y, bounds.min.y);
            isOnScreen = IsPositionOnScreen(new Vector3(x, y, 0));
        }
        while (isOnScreen);

        Instantiate(zombiePrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));
    }

    private bool IsPositionOnScreen(Vector3 position)
    {
        Vector3 screenPoint = playerCamera.WorldToViewportPoint(position);
        return (screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1);
    }
}