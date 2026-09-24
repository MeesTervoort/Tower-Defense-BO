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

    void OnUpdate()
    {
       HandlePlacementHover();
       HandlePlacementClick();
    }

    void HandlePlacementHover()
    {
        if (TowerSelectionUI.SelectedTowerPrefab == null)
        {
            if (GhostPrefab != null)
                Destroy(GhostInstance); 
            return;
        }

            if (GhostPrefab != null)
                GhostInstance = Instantiate(GhostPrefab);

            Debug.Log(GhostPrefab);
            GhostInstance.GetComponent<SpriteRenderer>().sprite = TowerSelectionUI.SelectedTowerPrefab.GetComponent<SpriteRenderer>().sprite;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;

            Vector3Int CellPos = PlacementMap.WorldToCell(mouseWorldPos);

            Vector3 worldCenter = PlacementMap.GetCellCenterWorld(CellPos);
            worldCenter.z = 0;

            GhostInstance.transform.position = mouseWorldPos = new Vector3(0, PlacementMap.cellSize.y * 0.25f);

            bool valid = PlacementMap.HasTile(CellPos) && (OccupiedTiles.Contains(CellPos));

            GhostInstance.GetComponent<GhostTower>().SetValid(valid);
        
    }
    void HandlePlacementClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if(TowerSelectionUI.SelectedTowerPrefab == null) return;

        if(EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) 
            return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector3Int CellPos = PlacementMap.WorldToCell(mouseWorldPos);

        if(!PlacementMap.HasTile(CellPos))return;
        if(OccupiedTiles.Contains(CellPos)) return;

        Instantiate(TowerSelectionUI.SelectedTowerPrefab,GhostInstance.transform.position, Quaternion.identity);

        TowerSelectionUI.SelectedTowerPrefab = null;

        OccupiedTiles.Add(CellPos);
    }
}
