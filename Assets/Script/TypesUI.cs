using System.Collections;
using Script;
using UnityEngine;
using UnityEngine.Events;

public class TypesUI : MonoBehaviour
{
    public TileType _tileTypeSelected;
    public TypeUI prefab;
    public Transform addButtonMenu;

    private void Start()
    {
        OnReset();
    }

    public void Selected(TileType _tileTypeDest)
    {
        _tileTypeSelected = _tileTypeDest;
    }

    public void OnAddType()
    {
        var instance = Instantiate(this.prefab, this.transform);
        addButtonMenu.SetSiblingIndex(transform.childCount - 1);
    }

    public void RemoveType()
    {
        if (transform.childCount > 2)
            Destroy(transform.GetChild(transform.childCount - 2).gameObject);
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

    public void ToReLoadTypes(TileType[] types)
    {
        StartCoroutine(ClearTypes());
        for (int i = 0; i < types.Length; i++)
        {
            var instance = Instantiate(this.prefab, this.transform);
            instance.gameObject.name = $"Type ({i})";
            instance.Setup(types[i]);
            addButtonMenu.SetSiblingIndex(transform.childCount - 1);
        }
        Selected(GetComponentsInChildren<TypeUI>()[0].tileType);
    }

    IEnumerator ClearTypes()
    {
        var typeUis = this.GetComponentsInChildren<TypeUI>();
        foreach (var typeUI in typeUis)
        {
            DestroyImmediate(typeUI.gameObject); //Destroy function only set gameobject enable=false, until next frame;
        }
        yield return null;
    }


    public void OnReset()
    {
        StartCoroutine(ClearTypes()); //Wait for Destroied Child to be removed in next Frame;
        for (var i = 0; i < 2; i++)
        {
            var instance = Instantiate(prefab, transform);
            instance.tileType.name = i == 0 ? "Grass" : "Sea";
            instance.tileType.Color = i == 0 ? Color.green : Color.blue;
            instance.gameObject.name = $"Type ({i})";
        }
        addButtonMenu.SetSiblingIndex(transform.childCount - 1);
        Selected(GetComponentsInChildren<TypeUI>()[0].tileType);
    }
}
