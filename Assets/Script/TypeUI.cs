using System;
using UnityEngine;
using UnityEngine.UI;

public class TypeUI : MonoBehaviour
{
    public TileType tileType;
    private TypesUI typesUI;
    public Text nameText;
    private Image image;
    private Button button;
    private Text ButtonText;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        typesUI = GetComponentInParent<TypesUI>();
        button = GetComponentInChildren<Button>();
        ButtonText = button.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        image.color = tileType.color;
        nameText.text = tileType.name;
        ButtonText.text = (typesUI._tileTypeSelected == this.tileType) ? "Selected" : "Select";
    }

    public void OnButtonDown()
    {
        typesUI.Selected(this.tileType);
    }
}
