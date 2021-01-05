using System;
using UnityEngine;

public class TypesUI : MonoBehaviour
{
    public TileType _tileTypeSelected;

    private void Start()
    {
        if (transform.GetChild(0) != null) _tileTypeSelected = transform.GetChild(0).GetComponent<TypeUI>().tileType;
    }

    public void Selected (TileType _tileTypeDest)
    {
        _tileTypeSelected = _tileTypeDest;
    }
}
