using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script
{
    [Serializable]
    public class Level
    {
        public string name;
        public string typesJson;
        public string mapJson;
    }

    [Serializable]
    public class Levels
    {
        public List<Level> levelsList;
    }
    public class DataManager : MonoBehaviour
    {
        public TypesUI typesUI;
        public MapUI mapUI;
        public InputField nameInput;

        private void Start()
        {
            nameInput.gameObject.SetActive(false);
            nameInput.onEndEdit.AddListener(ToSave);
        }

        public void OnSaving()
        {
            nameInput.gameObject.SetActive(true);
            EventSystem.current.SetSelectedGameObject(nameInput.gameObject,null);
        }

        private void ToSave(String name)
        {
            string path = Application.persistentDataPath + "/Data.json";
            var saveData = "";
            nameInput.gameObject.SetActive(false);
            var level = new Level();
            level.name = name;
            level.typesJson = typesUI.ToSaveTypes();
            level.mapJson = mapUI.ToSaveTiles();
            
            if(!File.Exists(path))
            {
                var levels = new Levels();
                var list = new List<Level>(){level};
                levels.levelsList = list;
                saveData = JsonUtility.ToJson(levels,true);
                var fileStream = File.Create(path);
                fileStream.Close();
            }
            else
            {
                string loadData = File.ReadAllText(path);
                Levels levels = JsonUtility.FromJson<Levels>(loadData);
                levels.levelsList.Add(level);
                saveData = JsonUtility.ToJson(levels, true);
            }
            // saveData = JsonUtility.ToJson(level, true);
            File.WriteAllText(path, saveData);
        }

        public void OnLoading()
        {
            string path = Application.persistentDataPath + "/Data.json";
            string loadData = System.IO.File.ReadAllText(path);
            // Level level = JsonUtility.FromJson<Level>(loadData);
            Levels levels = JsonUtility.FromJson<Levels>(loadData);
            Level level = levels.levelsList[0];
            var loadTypes = level.typesJson;
            TileType[] types = JsonHelper.FromJson<TileType>(loadTypes);
            typesUI.ToReLoadTypes(types);
            var loadTiles = level.mapJson;
            TileType[] tiles = JsonHelper.FromJson<TileType>(loadTiles);
            mapUI.ToReLoadTiles(tiles);
        }

        public void OnReset()
        {
            mapUI.OnReset();
            typesUI.OnReset();
        }
    }
}