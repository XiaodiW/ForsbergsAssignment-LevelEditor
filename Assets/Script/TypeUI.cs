using System;
using UnityEngine;
using UnityEngine.UI;

public class TypeUI : MonoBehaviour
{
    public TileType tileType;
    private TypesUI typesUI;
    public Text nameText;
    private Image image;
    public Button selectButton;
    private Text ButtonText;
    private FlexibleColorPicker colorPicker;
    bool colorPickerState;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        typesUI = GetComponentInParent<TypesUI>();
        ButtonText = selectButton.GetComponentInChildren<Text>();
        colorPicker = GetComponentInChildren<FlexibleColorPicker>();
        colorPicker.gameObject.SetActive(colorPickerState);
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

    public void OnImageClick()
    {
        colorPickerState = !colorPickerState;
        colorPicker.gameObject.SetActive(colorPickerState);
        image.color = colorPicker.color;
        tileType.color = image.color;
    }
}
