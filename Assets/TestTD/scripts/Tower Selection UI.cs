using UnityEngine;

public class TowerSelectionUI : MonoBehaviour
{
    public static GameObject SelectedTowerPrefab;
    
    public void SelectTower(GameObject towerPrefab)
    {
        if (SelectedTowerPrefab == towerPrefab)
        {
            SelectedTowerPrefab = null;
        }
        else
        {
            SelectedTowerPrefab = towerPrefab;
        }
        
    }
}
