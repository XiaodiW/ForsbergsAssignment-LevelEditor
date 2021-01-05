using System;
using UnityEngine;

public class TypesUI : MonoBehaviour
{
    public TileType _tileTypeSelected;

    private void Start()
    {
        // _tileTypeSelected = GetComponentInChildren<TileType>();
    }

    public void Selected (TileType _tileTypeDest)
    {
        _tileTypeSelected = _tileTypeDest;
    }
}
