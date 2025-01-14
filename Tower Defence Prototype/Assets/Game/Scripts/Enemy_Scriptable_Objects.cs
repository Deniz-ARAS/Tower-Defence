using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_Scriptable_Objects", menuName = "Scriptable Objects/Enemy_Scriptable_Objects")]
public class Enemy_Scriptable_Objects : ScriptableObject
{
    public string EnemyName;

    public int EnemyPowerRating;
    public float EnemySpeed;
    public int EnemyDamage;
    public int EnemyHealth;

    public GameObject EnemyPrefab;
}
