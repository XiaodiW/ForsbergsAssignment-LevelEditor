using UnityEngine;

public class TypesUI : MonoBehaviour
{
    public TileType _tileTypeSelected;

    public void Selected (TileType _tileTypeDest)
    {
        _tileTypeSelected = _tileTypeDest;
        // Debug.Log($"TileType Name is {_tileTypeSelected.name}");
    }
}
