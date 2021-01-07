using System;
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
        // if (tileType != null)
        //     Setup(tileType);
        // else
        // tileType = null;
        // image.color = Color.green;
        /*var temp = new TileType();
        temp.name = "default";
        temp.Color = Color.green;
        tileType = temp;*/
    }

    private void Update()
    {
        if (tileType != null) image.color = tileType.Color;
        Debug.Log($"{tileType.Color} Name {tileType.name}");
    }

    public void Setup(TileType type)
    {
        this.tileType = type;
        image.color = type.Color;
        // tileType.onColorChange.AddListener(OnColorChange);
    }

    /*private void OnColorChange(Color color)
    {
        image.color = color;
    }*/

    public void OnMouseDown()
    {
        tileType = typesUI._tileTypeSelected;
        image.color = tileType.Color;
        // tileType.onColorChange.AddListener(OnColorChange);
    }
}
