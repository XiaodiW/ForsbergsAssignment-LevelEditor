using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    private TypesUI _typesUI;
    private TileType _tileType;
    private Image image;
    // private Text _text;

    private void Start()
    {
        _typesUI = FindObjectOfType<TypesUI>();
        image = GetComponentInChildren<Image>();
        if (_tileType == null)
        {
            _tileType = new TileType();
            _tileType.name = "default";
            _tileType.color = Color.green;
        }
    }

    private void Update()
    {
        image.color = _tileType.color;
    }

    public void OnMouseDown()
    {
        Debug.Log($"G{_typesUI._tileTypeSelected.name}");
        _tileType = _typesUI._tileTypeSelected;
    }
}
