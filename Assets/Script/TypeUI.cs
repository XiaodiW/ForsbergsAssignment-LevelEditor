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
        image.color = tileType.color;
        nameText.text = tileType.name;

    }

    private void Update()
    {
        ButtonText.text = (typesUI._tileTypeSelected == this.tileType) ? "Selected" : "Select";
        if (colorPickerState)
        {
            image.color = colorPicker.color;
            tileType.color = image.color;
        }

    }

    public void OnButtonDown()
    {
        typesUI.Selected(this.tileType);
    }

    public void OnImageClick()
    {
        colorPickerState = !colorPickerState;
        colorPicker.gameObject.SetActive(colorPickerState);
    }
    //
    //
    // private void HideIfClickedOutside(GameObject panel) {
    //     if (Input.GetMouseButton(0) && panel.activeSelf &&
    //         !RectTransformUtility.RectangleContainsScreenPoint(
    //             panel.GetComponent<RectTransform>(),
    //             Input.mousePosition,
    //             Camera.main)) {
    //         // colorPickerState = !colorPickerState;
    //         colorPicker.gameObject.SetActive(false);
    //         // image.color = colorPicker.color;
    //         // tileType.color = image.color;
    //     }
    // }
}
