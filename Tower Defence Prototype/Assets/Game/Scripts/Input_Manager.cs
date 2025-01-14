using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    [SerializeField] private GameObject TurretObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layerMask = LayerMask.GetMask("Tile");

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.1f);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
            {
                Tile_Controller tileController = hit.collider.GetComponent<Tile_Controller>();
                if (tileController == null) return;

                if (!tileController.isOccupied)
                {
                    tileController.PlaceTower(TurretObject);
                }
                else if (tileController.isOccupied)
                {
                    Debug.Log("DestroyTower called");
                    tileController.DestroyTower();
                }
            }
        }
    }
}
