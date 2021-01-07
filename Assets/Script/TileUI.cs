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
        if (tileType != null)
            Setup(tileType);
        else
            image.color = Color.green;
    }

    public void Setup(TileType type)
    {
        this.tileType = type;
        image.color = type.Color;
        tileType.onColorChange.AddListener(OnColorChange);
    }

    private void OnColorChange(Color color)
    {
        image.color = color;
    }

    public void OnMouseDown()
    {
        tileType = typesUI._tileTypeSelected;
        image.color = tileType.Color;
        // tileType.onColorChange.AddListener(OnColorChange);
    }
}
