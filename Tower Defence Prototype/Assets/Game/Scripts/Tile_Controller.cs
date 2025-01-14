using UnityEngine;

public class Tile_Controller : MonoBehaviour
{
    [SerializeField] private Transform turretPlacementTransform;
    private GameObject turretObject;
    [SerializeField]
    public bool isOccupied = false;

    public void PlaceTower(GameObject TurretPrefab)
    {
        if (turretObject != null) Destroy(turretObject);
        turretObject = Instantiate(TurretPrefab, turretPlacementTransform, false);
        isOccupied = true;
    }

    public void DestroyTower()
    {
        if (turretObject != null)
        {
            Destroy(turretObject);
            isOccupied = false;
            turretObject = null;
        }
    }
}
