using System;
using UnityEngine;

public class TypesUI : MonoBehaviour
{
    public TileType _tileTypeSelected;
    public TypeUI prefab;
    public Transform addButtonMenu;

    private void Start()
    {
        if (transform.GetChild(0) != null) _tileTypeSelected = transform.GetChild(0).GetComponent<TypeUI>().tileType;
    }

    public void Selected (TileType _tileTypeDest)
    {
        _tileTypeSelected = _tileTypeDest;
    }

    public void OnAddType()
    {
        var instance = Instantiate(this.prefab, this.transform);
        // instance.GetComponent<TileType>().name = instance.name;
        // instance.GetComponent<TileType>().color = Color.green;
        addButtonMenu.SetSiblingIndex(transform.childCount - 1);
    }

    public void RemoveType()
    {
        if (transform.childCount > 2)
            Destroy(transform.GetChild(transform.childCount - 2).gameObject);
    }
}
