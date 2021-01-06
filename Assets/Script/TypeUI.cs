using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TypeUI : MonoBehaviour
{
    public TileType tileType;
    private TypesUI typesUI;
    public Text nameText;
    public Image colorImage;
    public Button selectButton;
    private Text ButtonText;
    private FlexibleColorPicker colorPicker;
    bool colorPickerState;
    private InputField nameInput;

    private void Start()
    {
        // colorImage = GetComponentInChildren<Image>();
        typesUI = GetComponentInParent<TypesUI>();
        ButtonText = selectButton.GetComponentInChildren<Text>();
        colorPicker = GetComponentInChildren<FlexibleColorPicker>();
        colorPicker.gameObject.SetActive(colorPickerState);
        nameInput = GetComponentInChildren<InputField>();
        colorImage.color = tileType.Color;
        nameText.text = tileType.name;
        nameInput.gameObject.SetActive(false);
        nameInput.text = tileType.name;
        tileType.typeID = gameObject.name;
    }

    private void Update()
    {
        ButtonText.text = (typesUI._tileTypeSelected == this.tileType) ? "Selected" : "Select";
        if (colorPickerState)
        {
            // colorImage.color = colorPicker.color;
            tileType.Color = colorPicker.color;
        }

        if (nameInput.gameObject.activeSelf) nameText.text = nameInput.text;
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

    public void OnNameClick()
    {
        nameInput.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(nameInput.gameObject,null);
    }

    public void OnNameClickEnd()
    {
        tileType.name = nameInput.text;
        nameInput.gameObject.SetActive(false);
    }
    
    
    /*private void HideIfClickedOutside(GameObject panel) {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main)) {
            // colorPickerState = !colorPickerState;
            colorPicker.gameObject.SetActive(false);
            // image.color = colorPicker.color;
            // tileType.Color = image.color;
        }
    }*/
}
