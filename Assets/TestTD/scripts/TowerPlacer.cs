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
        if(TowerSelectionUI.SelectedTowerPrefab == null)
        {
            if(GhostPrefab != null)
            {
                Destroy(GhostPrefab);
            }
            return;

            if (GhostPrefab == null)
                GhostInstance = Instantiate(GhostPrefab);

            GhostInstance.GetComponent<SpriteRenderer>().sprite = TowerSelectionUI.SelectedTowerPrefab.GetComponent<SpriteRenderer>().sprite;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
        }
    }
    void HandlePlacementClick()
    {

    }
}
