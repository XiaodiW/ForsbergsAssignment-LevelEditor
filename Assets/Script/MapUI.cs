using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class MapUI : MonoBehaviour
    {
        public TileUI prefab;
        public GameObject typesUI;
        public Button editButton;
        public Dropdown xValue;
        public Dropdown yValue;
        public Button okButton;
        private int mapSize = 100;
        private List<int> sizeOptions = new List<int>(){2,3,5,8,10,20,50,100};
        private RectTransform _rectTransform;
        private GridLayoutGroup gridLayoutGroup;
        public int xGrid = 10;
        Vector2 cellSize = new Vector2(70, 70);
        

        private void Start()
        {
            xValue.gameObject.SetActive(false);
            yValue.gameObject.SetActive(false);
            okButton.gameObject.SetActive(false);
            gridLayoutGroup = GetComponent<GridLayoutGroup>();
            _rectTransform = GetComponent (typeof (RectTransform)) as RectTransform;
            OnReset();
        }

        public void OnEdit()
        {
            List<string> optionsString = new List<string>();
            foreach (var option in sizeOptions)
            {
                optionsString.Add(option.ToString());
            }
            xValue.ClearOptions();
            xValue.AddOptions(optionsString);
            yValue.ClearOptions();
            yValue.AddOptions(optionsString);
            xValue.gameObject.SetActive(true);
            yValue.gameObject.SetActive(true);
            okButton.gameObject.SetActive(true);
        }

        public void OnOK()
        {
            xValue.gameObject.SetActive(false);
            yValue.gameObject.SetActive(false);
            okButton.gameObject.SetActive(false);
            xGrid = sizeOptions[xValue.value];
            mapSize = xGrid * sizeOptions[yValue.value];
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
            mapSize = tiles.Length;
            OnReset();
            var types = typesUI.GetComponentsInChildren<TypeUI>();
            for (int i = 0; i < tiles.Length; i++)
            {
                var instance = Instantiate(this.prefab, this.transform);
                foreach (var type in types)
                {
                    if (tiles[i].name == type.tileType.name && tiles[i].Color == type.tileType.Color)
                        instance.Setup(type.tileType);
                }
            }
        }

        void ToSetRect(int xGrid, int mapSize)
        {
            var yGrid = mapSize / xGrid;
            if (xGrid > yGrid)
            {
                var y = (yGrid/xGrid)*800f;
                _rectTransform.sizeDelta = new Vector2 (800f, y);
                cellSize = new Vector2(800f / xGrid - 10f, 800f / xGrid - 10f);
            }
            else
            {
                var x = (xGrid/yGrid)*800f;
                _rectTransform.sizeDelta = new Vector2 (x, 800f);
                cellSize = new Vector2(800f / yGrid - 10f, 800f / yGrid - 10f);
            }

            gridLayoutGroup.cellSize = cellSize;
        }

        public void OnReset()
        {
            ClearMap();
            ToSetRect(xGrid, mapSize);
            typesUI.GetComponent<TypesUI>().OnReset();
            var typeUIs = typesUI.GetComponentsInChildren<TypeUI>();
            for (var i = 0; i < mapSize; i++)
            {
                var instance = Instantiate(prefab, transform);
                instance.Setup(typeUIs[0].tileType);
            }
        }

        private void ClearMap()
        {
            var tileUis = GetComponentsInChildren<TileUI>();
            foreach (var tileUi in tileUis) Destroy(tileUi.gameObject);
        }
    }
}