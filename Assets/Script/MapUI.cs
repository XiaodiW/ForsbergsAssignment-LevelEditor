using System;
using Script;
using UnityEngine;

namespace Script
{
    /*[Serializable]
    public class Tile
    {
        public string tileName;
        public Color tileColor;
    }*/
    
    public class MapUI : MonoBehaviour
    {
        public TileUI prefab;
        public GameObject typesUI;
        
        public string ToSaveTiles()
        {
            var tileUis = GetComponentsInChildren<TileUI>();
            TileType[] tiles = new TileType[tileUis.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = tileUis[i].tileType;
            }
            var saveTiles = JsonHelper.ToJson(tiles, true);
            Debug.Log($"{saveTiles}");
            return saveTiles;
        }

        public void ToReLoadTiles(TileType[] tiles)
        {
            var tileUis = GetComponentsInChildren<TileUI>();
            foreach (var tileUi in tileUis)
            {
                Destroy(tileUi.gameObject);
            }

            for (int i = 0; i < tiles.Length; i++)
            {
                var instance = Instantiate(this.prefab, this.transform);
                var types = typesUI.GetComponentsInChildren<TypeUI>();
                foreach (var type in types)
                {
                    if (tiles[i].name == type.tileType.name && tiles[i].Color == type.tileType.Color)
                        instance.Setup(type.tileType);
                }
            }
        }
    }
}