using System;
using Script;
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

    public void OnSaving()
    {
        Debug.Log(ToSaveTypes());
        // Debug.Log(Application.persistentDataPath);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", ToSaveTypes());
    }

    public void OnLoading()
    {
        string loadTypes = System.IO.File.ReadAllText(Application.persistentDataPath + "/Data.json");
        TileType[] types = JsonHelper.FromJson<TileType>(loadTypes);
        ReLoadTypes(types);
    }

    public string ToSaveTypes()
    {
        var typeUis = GetComponentsInChildren<TypeUI>();
        TileType[] types = new TileType[typeUis.Length];
        for (int i = 0; i < typeUis.Length; i++)
        {
             types[i] = typeUis[i].tileType;
        }
        var saveTypes = JsonHelper.ToJson(types, true);
        return saveTypes;
    }

    public void ReLoadTypes(TileType[] types)
    {
        var typeUis = GetComponentsInChildren<TypeUI>();
        foreach (var typeUI in typeUis)
        {
            Destroy(typeUI.gameObject);
        }

        for (int i = 0; i < types.Length; i++)
        {
            var instance = Instantiate(this.prefab, this.transform);
            instance.tileType.typeID = types[i].typeID;
            instance.tileType.name = types[i].name;
            instance.tileType.Color = types[i].Color;
            instance.name = $"TileType({i})";
            addButtonMenu.SetSiblingIndex(transform.childCount - 1);
        }
        if (transform.GetChild(0) != null) _tileTypeSelected = transform.GetChild(0).GetComponent<TypeUI>().tileType;
    }
}
