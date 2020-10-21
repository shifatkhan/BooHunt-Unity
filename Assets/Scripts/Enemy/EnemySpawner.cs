using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner attributes")]
    [SerializeField]
    private Direction directionToSpawn = Direction.RIGHT;
    [SerializeField]
    private bool enabledForSpecialMode = true;

    public void SetDirectionToSpawn(Direction newDir)
    {
        this.directionToSpawn = newDir;
    }

    public void Spawn(GameObject prefabToSpawn)
    {
        GameObject spawned = Instantiate(prefabToSpawn, transform.position, prefabToSpawn.transform.rotation);
        EnemyMovement enemySpawned = spawned.GetComponent<EnemyMovement>();

        enemySpawned.SetDirection(directionToSpawn);
        // TODO: Change speed according to level.
        //enemySpawned.SetSpeed();
    }

    public void SetEnabledForSpecialMode(bool enable)
    {
        enabledForSpecialMode = enable;
    }
}
