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
        if (transform.GetChild(0) != null) _tileTypeSelected = transform.GetChild(0).GetComponent<TypeUI>().tileType;
    }

    public void Selected (TileType _tileTypeDest)
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
        var typeUis = GetComponentsInChildren<TypeUI>();
        foreach (var typeUI in typeUis)
        {
            Destroy(typeUI.gameObject);
        }

        for (int i = 0; i < types.Length; i++)
        {
            var instance = Instantiate(this.prefab, this.transform);
            instance.gameObject.name = $"Type ({i})";
            instance.Setup(types[i]);
            addButtonMenu.SetSiblingIndex(transform.childCount - 1);
        }
        Debug.Log($"{transform.GetChild(0).name}"); 
        if (transform.GetChild(0) != null) Selected (transform.GetChild(0).GetComponent<TypeUI>().tileType);
    }
}
