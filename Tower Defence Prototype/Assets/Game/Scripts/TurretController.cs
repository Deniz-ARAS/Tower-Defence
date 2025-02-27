using DG.Tweening;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    Turret_Scriptable_Object TurretSO;
    [SerializeField]
    Transform shootingTransfrom;
    private void Start()
    {
        InvokeRepeating("ShootBullet", 0f, TurretSO.TurretFireRate);
    }

    private void ShootBullet()
    {
        transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0.15f), 0.5f);
        Instantiate(TurretSO.TurretProjectile, shootingTransfrom.position, shootingTransfrom.rotation);
    }
}
