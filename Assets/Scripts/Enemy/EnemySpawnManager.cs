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

    [Header("Enemy Spawn frequencies")]
    [SerializeField]
    private float ghostSpawnRate = 2.0f;
    private float ghostSpawnTime = 0.0f;

    private float witchSpawnRate = 2.0f;
    private float witchSpawnTime = 0.0f;

    [SerializeField]
    private int minWitchSpawnFrequency = 2;
    [SerializeField]
    private int maxWitchSpawnFrequency = 4;

    private GameManager gm;

    void Start()
    {
        spawners = GetComponentsInChildren<EnemySpawner>();
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

        // Spawn witch 2 - 5 times.
        witchSpawnRate = gm.GetTotalTime() / (int)Random.Range(minWitchSpawnFrequency, maxWitchSpawnFrequency+1);
        witchSpawnTime += witchSpawnRate; // So the witch doesn't spawn right away.
    }

    void Update()
    {
        // Check if we should spawn ghost.
        if (Time.time > ghostSpawnTime)
        {
            ghostSpawnTime += ghostSpawnRate;

            SpawnGhost();
        }

        // TODO: Ghost spawn rate decreases in special mode

        // Check if we should spawn witch.
        if (Time.time > witchSpawnTime)
        {
            witchSpawnTime += witchSpawnRate;

            SpawnWitch();
        }

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
