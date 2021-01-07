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
        public int xGrid;
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
        public Button loadButton;
        public Dropdown dropDownList;
        private Levels levelsTransfer;
        public Text levelName;

        private void Start()
        {
            nameInput.gameObject.SetActive(false);
            nameInput.onEndEdit.AddListener(ToSave);
            dropDownList.gameObject.SetActive(false);
            // dropDownList.value = 0; //[0] element cannot be selected. Then it will be a emputy.
            dropDownList.onValueChanged.AddListener(ToLoad);
            string path = Application.persistentDataPath + "/Data.json";
            loadButton.gameObject.SetActive(File.Exists(path));
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
            levelName.text = name;
            level.typesJson = typesUI.ToSaveTypes();
            level.mapJson = mapUI.ToSaveTiles();
            level.xGrid = mapUI.xGrid;
            
            if(!File.Exists(path))
            {
                var levels = new Levels(); //Create new Levels Class
                Level emputyLevel = new Level();
                emputyLevel.xGrid = 10;
                emputyLevel.mapJson = level.mapJson;
                emputyLevel.typesJson = level.typesJson;
                emputyLevel.name = "Select Saved Level";
                var list = new List<Level>(){emputyLevel}; //add a emputy level to the list;
                list.Add(level); //Add first level to the list;
                levels.levelsList = list; //assign the Emputy level and fist level to Levels Class List.
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
            loadButton.gameObject.SetActive(File.Exists(path));
        }

        public void OnLoading()
        {
            string path = Application.persistentDataPath + "/Data.json";
            string loadData = System.IO.File.ReadAllText(path);
            // Level level = JsonUtility.FromJson<Level>(loadData);
            levelsTransfer = JsonUtility.FromJson<Levels>(loadData);
            List<string> levelList = new List<string>();
            foreach (var list in levelsTransfer.levelsList)
            {
                levelList.Add(list.name);
            }
            dropDownList.ClearOptions();
            dropDownList.AddOptions(levelList);
            // dropDownList.value = -1; //value change event can only by trigged. but the defould value is 0. first can not be selected.
            dropDownList.gameObject.SetActive(true);
        }

        public void ToLoad(int i)
        {
            dropDownList.gameObject.SetActive(false);
            Level level = levelsTransfer.levelsList[i];
            levelName.text = level.name;
            mapUI.xGrid = level.xGrid;
            var loadTypes = level.typesJson;
            TileType[] types = JsonHelper.FromJson<TileType>(loadTypes);
            typesUI.ToReLoadTypes(types);
            var loadTiles = level.mapJson;
            TileType[] tiles = JsonHelper.FromJson<TileType>(loadTiles);
            mapUI.ToReLoadTiles(tiles);
        }

        public void OnReset()
        {
            mapUI.xGrid = 10;
            mapUI.mapSize = 100;
            mapUI.OnReset(true);
            // typesUI.OnReset();
        }
    }
}