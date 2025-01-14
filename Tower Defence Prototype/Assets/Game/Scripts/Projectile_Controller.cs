using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    [SerializeField]
    public Projectile_Scriptable_Objects ProjectileSO;

    private void Update()
    {
        CheckForClosestEnemy();
        transform.Translate(Vector3.forward * ProjectileSO.ProjectileSpeed * Time.deltaTime);
    }

    private void CheckForClosestEnemy()
    {
        // Find all enemies in the scene (you can optimize this by only storing active enemies in a list)
        Enemy_Controllar[] allEnemies = FindObjectsOfType<Enemy_Controllar>();

        float closestDistance = float.MaxValue;
        Enemy_Controllar closestEnemy = null;

        // Loop through all enemies and check the distance to each one
        foreach (Enemy_Controllar enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is the closest and within the damage threshold
            if (distanceToEnemy < closestDistance && distanceToEnemy <= ProjectileSO.DamageThreshold)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // If a closest enemy is found and is within the damage threshold, apply damage
        if (closestEnemy != null)
        {
            closestEnemy.TakeDamage(ProjectileSO.ProjectileDamage);
            Destroy(gameObject);  // Destroy the projectile after it hits the enemy
        }
    }
}
