using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    private TypesUI typesUI;
    public TileType tileType;
    private Image image;

    private void Start()
    {
        typesUI = FindObjectOfType<TypesUI>();
        image = GetComponentInChildren<Image>();
        if (tileType == null)
        {
            image.color = Color.green;
        }
        else
        {
            tileType.onColorChange.AddListener(OnColorChange);
        }
    }

    private void OnColorChange(Color color)
    {
        image.color = color;
    }

    public void OnMouseDown()
    {
        tileType = typesUI._tileTypeSelected;
        image.color = tileType.Color;
        tileType.onColorChange.AddListener(OnColorChange);
    }
}
