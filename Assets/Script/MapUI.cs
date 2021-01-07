using System;
using UnityEngine;

namespace Script
{
    public class MapUI : MonoBehaviour
    {
        public TileUI prefab;
        public GameObject typesUI;

        private void Start()
        {
            OnReset();
        }

        public string ToSaveTiles()
        {
            var tileUis = GetComponentsInChildren<TileUI>();
            TileType[] tiles = new TileType[tileUis.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = tileUis[i].tileType;
            }
            var saveTiles = JsonHelper.ToJson(tiles, true);
            return saveTiles;
        }

        public void ToReLoadTiles(TileType[] tiles)
        {
            ClearMap();
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

        private void ClearMap()
        {
            var tileUis = GetComponentsInChildren<TileUI>();
            foreach (var tileUi in tileUis)
            {
                Destroy(tileUi.gameObject);
            }
        }
        public void OnReset()
        {
            ClearMap();
            for (var i = 0; i < 100; i++)
            {
                var instance = Instantiate(prefab, transform);
            }
        }
    }
}