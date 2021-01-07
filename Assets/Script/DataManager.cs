using System;
using UnityEngine;

namespace Script
{
    public class DataManager : MonoBehaviour
    {
        public TypesUI typeUI;
        public MapUI mapUI;
        
        public void OnSaving()
        {
            // Debug.Log(Application.persistentDataPath);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Types.json", typeUI.ToSaveTypes());
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Tiles.json", mapUI.ToSaveTiles());

        }

        public void OnLoading()
        {
            string loadTypes = System.IO.File.ReadAllText(Application.persistentDataPath + "/Types.json");
            TileType[] types = JsonHelper.FromJson<TileType>(loadTypes);
            typeUI.ToReLoadTypes(types);
            string loadTiles = System.IO.File.ReadAllText(Application.persistentDataPath + "/Tiles.json");
            Tile[] tiles = JsonHelper.FromJson<Tile>(loadTiles);
            mapUI.ToReLoadTiles(tiles);
        }
    }
}