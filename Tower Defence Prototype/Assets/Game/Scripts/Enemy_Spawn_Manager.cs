using UnityEngine;
using System.Collections;

public class Enemy_Spawn_Manager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] EnemySpawnPoints;
    [SerializeField] private float spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (EnemySpawnPoints.Length > 0)
        {
            GameObject spawnPoint = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Length)];
            Enemy_Spawner enemySpawner = spawnPoint.GetComponent<Enemy_Spawner>();
            enemySpawner.SpawnEnemy(enemyPrefab);
        }
    }
}
