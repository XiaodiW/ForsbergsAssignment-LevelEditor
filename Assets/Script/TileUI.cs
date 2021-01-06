using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    private TypesUI typesUI;
    public TileType tileType;
    public Image image;

    private void Start()
    {
        typesUI = FindObjectOfType<TypesUI>();
        // image = GetComponent<Image>();
        // if (tileType == null)
        // {
            // tileType = new TileType();
            // tileType.name = "Default";
            // tileType.Color = Color.green;
            // image.color = tileType.Color;
        // }
        // else
        // {
            tileType.onColorChange.AddListener(OnColorChange);
        // }
    }

    public void Setup(TileType type)
    {
        this.tileType = type;
        image.color = type.Color;
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
