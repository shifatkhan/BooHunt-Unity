using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Spawner attributes")]
    private EnemySpawner[] spawners;

    [Header("Enemy Prefabs")]
    [SerializeField]
    private GameObject ghostPrefab;
    [SerializeField]
    private GameObject witchPrefab;

    // Spawn timers.
    private float ghostSpawnTime = 0.0f;
    private float ghostSpawnRate = 2.0f;

    private float witchSpawnTime = 0.0f;
    private float witchSpawnRate = 2.0f;

    void Start()
    {
        spawners = GetComponentsInChildren<EnemySpawner>();
    }

    void Update()
    {
        // Check if we should spawn.
        if (Time.time > ghostSpawnTime)
        {
            ghostSpawnTime += ghostSpawnRate;

            SpawnGhost();
        }

        // TODO: Ghost spawn rate decreases as level rises

        // TODO: Calculate Witch spawn rate (at least 2 per game)
    }

    public void SpawnGhost()
    {
        RandomSpawn(ghostPrefab);
    }

    public void SpawnWitch()
    {
        RandomSpawn(witchPrefab);
    }

    private void RandomSpawn(GameObject prefab)
    {
        int spawnIndex = Random.Range(0, spawners.Length);
        spawners[spawnIndex].Spawn(prefab);
    }
}
