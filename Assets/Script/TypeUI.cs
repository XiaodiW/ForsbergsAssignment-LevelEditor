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
    public Text ButtonText;
    public FlexibleColorPicker colorPicker;
    bool colorPickerState;
    public InputField nameInput;

    private void Start()
    {
        typesUI = GetComponentInParent<TypesUI>();
        colorPicker.gameObject.SetActive(colorPickerState);
        nameInput.gameObject.SetActive(false);
        Setup(tileType);
    }

    public void Setup(TileType type)
    {
        tileType = type;
        colorImage.color = type.Color;
        nameText.text = type.name;
        nameInput.text = type.name;
    }
    
    private void Update()
    {
        ButtonText.text = (typesUI._tileTypeSelected == this.tileType) ? "Selected" : "Select";
        if (colorPickerState)
        {
            tileType.Color = colorPicker.color;
            colorImage.color = tileType.Color;
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
