using System;
using UnityEngine;

namespace Script
{

    public class Level
    {
        public String name;
        public string typesJson;
        public string mapJson;
    }
    public class DataManager : MonoBehaviour
    {
        public TypesUI typeUI;
        public MapUI mapUI;
        
        public void OnSaving()
        {
            var level = new Level();
            level.name = "Level 1";
            level.typesJson = typeUI.ToSaveTypes();
            level.mapJson = mapUI.ToSaveTiles();
            // Debug.Log(Application.persistentDataPath);
            // System.IO.File.WriteAllText(Application.persistentDataPath + "/Types.json", typeUI.ToSaveTypes());
            // System.IO.File.WriteAllText(Application.persistentDataPath + "/Tiles.json", mapUI.ToSaveTiles());
            var saveData = JsonUtility.ToJson(level, true);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/Data.json", saveData);
        }

        public void OnLoading()
        {
            string loadData = System.IO.File.ReadAllText(Application.persistentDataPath + "/Data.json");
            Level level = JsonUtility.FromJson<Level>(loadData);
            // string loadTypes = System.IO.File.ReadAllText(Application.persistentDataPath + "/Types.json");
            var loadTypes = level.typesJson;
            TileType[] types = JsonHelper.FromJson<TileType>(loadTypes);
            typeUI.ToReLoadTypes(types);
            // string loadTiles = System.IO.File.ReadAllText(Application.persistentDataPath + "/Tiles.json");
            var loadTiles = level.mapJson;
            Tile[] tiles = JsonHelper.FromJson<Tile>(loadTiles);
            mapUI.ToReLoadTiles(tiles);
        }
    }
}