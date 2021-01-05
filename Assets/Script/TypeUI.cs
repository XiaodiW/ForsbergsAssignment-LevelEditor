using System;
using UnityEngine;
using UnityEngine.UI;

public class TypeUI : MonoBehaviour
{
    public TileType tileType;
    private TypesUI _typesUI;
    // public GameObject background;
    // public string name;
    // public Color color;
    public Text nameUI;
    private Image image;
    private Button _button;
    private Text buttonText;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        _typesUI = GetComponentInParent<TypesUI>();
        _button = GetComponentInChildren<Button>();
        buttonText = _button.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        image.color = tileType.color;
        nameUI.text = tileType.name;
        buttonText.text = (_typesUI._tileTypeSelected == this.tileType) ? "Selected" : "Select";
        // background.SetActive(_typesUI._tileTypeSelected == this.tileType);

    }

    public void OnButtonDown()
    {
        _typesUI.Selected(this.tileType);
    }
}
