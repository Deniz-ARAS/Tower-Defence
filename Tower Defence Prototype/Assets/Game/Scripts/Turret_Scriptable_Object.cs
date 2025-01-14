using UnityEngine;

[CreateAssetMenu(fileName = "Turret_Scriptable_Object", menuName = "Scriptable Objects/Turret_Scriptable_Object")]
public class Turret_Scriptable_Object : ScriptableObject
{
    public string TurretName;

    public float TurretCost;

    public float TurretFireRate;
    public GameObject TurretObject;
    public GameObject TurretProjectile;
}
