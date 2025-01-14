using UnityEngine;

public class Enemy_Controllar : MonoBehaviour
{
    [SerializeField]
    Enemy_Scriptable_Objects EnemySO;
    private int health;
    private float speed;
    private int damage;


    private void Start()
    {
        health = EnemySO.EnemyHealth;
        speed = EnemySO.EnemySpeed;
        damage = EnemySO.EnemyDamage;
    }

    private void Update()
    {
        MoveEnemy();
    }


    public void TakeDamage(int damageAmount)
    {
        if (health > 0)
        {
            health -= damageAmount;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
