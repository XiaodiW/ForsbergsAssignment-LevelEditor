using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TileType
{
    public string name;
    public Color color;
    public UnityEvent<Color> onColorChange;
    
    public Color Color
    {
        get => color;
        set
        {
            color = value;
            onColorChange.Invoke(color);
        } 
    }
}
