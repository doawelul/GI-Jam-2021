using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameOverReason endReason;
    private static string currentBuilding;

    private Grid layout;

    private static int gold;
    private static int food;
    private static int stone;

    private static int goldChange;
    private static int foodChange;
    private static int stoneChange;

    // tile sprites. instantiated from unity side
    public GameObject DEEP;
    public GameObject WATER;
    public GameObject ROCK;
    public GameObject GRASS;
    public GameObject SAND;

    public GameObject[] buildings;
    public Text[] resourceAmounts;
    public MapData level;

    private void Start()
    {
        currentBuilding = "C";

        gold = 20;
        food = 3;
        stone = 10;

        SetText();

        loadTileSprites();

        layout = new Grid(level.mapName, buildings);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            layout.setBuilding((int)GridPosition().x, (int)GridPosition().y);
            SetText();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            GameOver("You have ended the game of your own choosing.");
    }

    private void loadTileSprites()
    {
        Tile.DEEP_SPRITE = DEEP;
        Tile.WATER_SPRITE = WATER;
        Tile.ROCK_SPRITE = ROCK;
        Tile.GRASS_SPRITE = GRASS;
        Tile.SAND_SPRITE = SAND;
    }

    private Vector2 GridPosition()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = 10.0F;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.x = ((v3.x + 0.5F) >= 0 ? (int)(v3.x + 0.5F) : -1);
        v3.y = ((v3.y + 0.5F) >= 0 ? (int)(v3.y + 0.5F) : -1);

        return new Vector2(v3.x, v3.y);
    }

    private void GameOver(string message)
    {
        endReason.reason = message;
        SceneManager.LoadScene(2);
    }

    private void SetText()
    {
        resourceAmounts[0].text = "Gold: " + gold + " (" + goldChange + ")";
        resourceAmounts[1].text = "Food: " + food + " (" + foodChange + ")";
        resourceAmounts[2].text = "Stone: " + stone + " (" + stoneChange + ")";
    }

    public void buttonSelect(string type)
    {
        if (currentBuilding == "C")
            return;

        currentBuilding = type;
    }

    public void BuildUnit(string type)
    {

    }

    public void StartTurn()
    {
        gold += goldChange;
        food += foodChange;
        stone += stoneChange;

        if (gold < 0) 
            GameOver("You have run out of Gold.");
        else if(food < 0)
            GameOver("You have run out of Food.");
        else if (stone < 0)
            GameOver("You have run out of Stone.");
        SetText();
    }

    public void EndTurn()
    {
        //Do enemy turn
        StartTurn();
    }

    private class Grid
    {
        /*private const Tile.TileType G = Tile.TileType.GRASS;
        private const Tile.TileType D = Tile.TileType.DEEP;
        private const Tile.TileType S = Tile.TileType.SAND;
        private const Tile.TileType R = Tile.TileType.ROCK;
        private const Tile.TileType W = Tile.TileType.WATER;*/

        private const int ROW = 10;
        private const int COL = 10;
        /*private readonly Tile.TileType[,] tileTypes =
            {{G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G}};*/

        private Tile[,] gridData = new Tile[ROW, COL];


        private GameObject[] buildings;


        public Grid(string map, GameObject[] g)
        {
            buildings = g;

            string[] temp = File.ReadAllText("Assets/Maps/" + map + ".txt").Split('\n');
            Debug.Log(temp[9].ToCharArray()[9]);

            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                {
                    Tile.TileType tempType = Tile.TileType.GRASS;
                    //setTile(i, j, tileTypes[i, j]);
                    switch (temp[i].ToCharArray()[j])
                    {
                        case 'G':
                            tempType = Tile.TileType.GRASS;
                            break;
                        case 'R':
                            tempType = Tile.TileType.ROCK;
                            break;
                        case 'S':
                            tempType = Tile.TileType.SAND;
                            break;
                        case 'W':
                            tempType = Tile.TileType.WATER;
                            break;
                        case 'D':
                            tempType = Tile.TileType.DEEP;
                            break;
                    }
                    setTile(i, j, tempType);
                }
        }

        public Tile getTile(int row, int col)
        {
            return gridData[row, col];
        }

        public void setTile(int row, int col, Tile.TileType type)
        {
            Tile createdTile = new Tile(type);
            gridData[row, col] = createdTile;
            Tile.createGameTile(row, col, createdTile);
        }

        public void setBuilding(int row, int col)
        {
            if (row < 0 || col < 0 || row > 9 || col > 9 || gridData[row, col].getBuilding() != null)
                return;

            if (currentBuilding != "C" && !SearchAdjacent(row, col))
                return;

            if (stone < 2)
                return;

            if (!gridData[row, col].CanBuild())
                return;

            GameObject temp;

            switch (currentBuilding)
            {
                case "F":
                    temp = Instantiate(buildings[0], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    gridData[row, col].setFarm(temp);
                    break;
                case "R":
                    temp = Instantiate(buildings[1], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    gridData[row, col].setRoad(temp);
                    break;
                case "M":
                    temp = Instantiate(buildings[2], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    gridData[row, col].setMine(temp);
                    break;
                case "B":
                    temp = Instantiate(buildings[3], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    gridData[row, col].setBank(temp);
                    break;
                case "C":
                    temp = Instantiate(buildings[4], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    gridData[row, col].setCastle(temp);
                    currentBuilding = "";
                    break;
                case "":
                    return;
            }

            stone -= 2;
            goldChange += gridData[row, col].GetGoldChange();
            foodChange += gridData[row, col].GetFoodChange();
            stoneChange += gridData[row, col].GetStoneChange();
        }

        private bool SearchAdjacent(int row, int col)
        {
            if (row > 0 && gridData[row - 1, col].getBuilding() != null)
                return true;

            if (row < 9 && gridData[row + 1, col].getBuilding() != null)
                return true;

            if (col > 0 && gridData[row, col - 1].getBuilding() != null)
                return true;

            if (col < 9 && gridData[row, col + 1].getBuilding() != null)
                return true;

            return false;
        }
    }
}