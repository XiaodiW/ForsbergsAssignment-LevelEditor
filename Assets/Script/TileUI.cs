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
    }

    private void Update()
    {
        if (tileType != null) image.color = tileType.Color;
    }

    public void Setup(TileType type)
    {
        this.tileType = type;
        image.color = type.Color;
        // tileType.onColorChange.AddListener(OnColorChange);
    }
    
    public void OnMouseDown()
    {
        tileType = typesUI._tileTypeSelected;
        image.color = tileType.Color;
    }
}
