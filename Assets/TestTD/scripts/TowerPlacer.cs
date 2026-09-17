using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class TowerPlacer : MonoBehaviour
{
    public Tilemap PlacementMap;
    public Tilemap NonPlaceableMap;

    public GameObject GhostPrefab;

    private HashSet<Vector3Int> OccupiedTiles = new HashSet<Vector3Int>();
    private GameObject GhostInstance;

    void Update()
    {
       HandlePlacementHover();
       HandlePlacementClick();


    }
    void HandlePlacementHover()
    {
        if (TowerSelectionUI.SelectedTowerPrefab == null)
        {
            if (GhostPrefab != null)
            {
                Destroy(GhostPrefab);
            }
            return;

            if (GhostPrefab == null)
                GhostInstance = Instantiate(GhostPrefab);

            GhostInstance.GetComponent<SpriteRenderer>().sprite = TowerSelectionUI.SelectedTowerPrefab.GetComponent<SpriteRenderer>().sprite;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            GhostInstance.transform.position = mouseWorldPos = new Vector3(0, PlacementMap.cellSize.y * 0.25f);

            bool valid = PlacementMap.HasTile(CellPos) && (OccupiedTiles.Contains(CellPos);

            GhostInstance.GetComponent<GhostTower>().SetValid(valid);
        }
    }
    void HandlePlacementClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if(TowerSelectionUI.SelectedTowerPrefab == null) return;

        if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) 
            return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
    }
}
