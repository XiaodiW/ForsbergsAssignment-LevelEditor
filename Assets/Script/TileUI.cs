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

    private void Start()
    {
        _typesUI = FindObjectOfType<TypesUI>();
        image = GetComponentInChildren<Image>();
        if (_tileType == null)
        {
            // _tileType = new TileType();
            // _tileType.name = "default";
            // _tileType.Color = Color.green;
            image.color = Color.green;
        }
        else
        {
            _tileType.onColorChange.AddListener(OnColorChange);
        }
    }

    private void OnColorChange(Color color)
    {
        image.color = color;
    }

    public void OnMouseDown()
    {
        _tileType = _typesUI._tileTypeSelected;
        image.color = _tileType.Color;
        _tileType.onColorChange.AddListener(OnColorChange);
    }
}
