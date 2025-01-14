using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    [SerializeField]
    public GameObject enemyPrefab;
    [SerializeField]
    Transform enemySpawnTransform;
    public void SpawnEnemy(GameObject EnemyPrefab)
    {
        if (enemyPrefab != null)
        {
            Instantiate(EnemyPrefab, enemySpawnTransform, false);
        }
    }
}
