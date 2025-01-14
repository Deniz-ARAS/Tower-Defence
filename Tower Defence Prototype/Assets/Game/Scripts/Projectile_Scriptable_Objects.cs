using UnityEngine;

[CreateAssetMenu(fileName = "Projectile_Scriptable_Objects", menuName = "Scriptable Objects/Projectile_Scriptable_Objects")]
public class Projectile_Scriptable_Objects : ScriptableObject
{

    public GameObject ProjectilePrefab;
    public int ProjectileDamage;
    public float ProjectileSpeed;
    public float DamageThreshold;
}
