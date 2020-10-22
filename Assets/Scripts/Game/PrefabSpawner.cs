using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
	private float nextSpawn = 0;

	// Reference to the Prefab to spawn
	public Transform[] prefabsToSpawn;

	public float randomDelay = 10;
	public float spawnRate = 5;

	// Use this for initialization
	void Start()
	{
		nextSpawn = (Time.time + spawnRate + Random.Range(0, randomDelay)) / 2;
	}

	// Update is called once per frame
	void Update()
	{
		if (Time.time > nextSpawn)
		{
			Instantiate(prefabsToSpawn[Random.Range(0,prefabsToSpawn.Length)], transform.position, Quaternion.identity);

			nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
		}
	}
}
