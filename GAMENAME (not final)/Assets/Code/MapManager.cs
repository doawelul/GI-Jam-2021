using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private string currentBuilding;
    Grid layout;

    // tile sprites. instantiated from unity side
    public GameObject DEEP;
    public GameObject WATER;
    public GameObject ROCK;
    public GameObject GRASS;
    public GameObject SAND;

    public GameObject CASTLE;
    public GameObject FARM;
    public GameObject MINE;
    public GameObject BANK;
    public GameObject ROAD;

    public GameObject[] buildings;

    private void loadTileSprites() {
        Tile.DEEP_SPRITE = DEEP;
        Tile.WATER_SPRITE = WATER;
        Tile.ROCK_SPRITE = ROCK;
        Tile.GRASS_SPRITE = GRASS;
        Tile.SAND_SPRITE = SAND;
    }

    private void Start()
    {
        loadTileSprites();
        layout = new Grid(buildings);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            layout.setBuilding((int)GridPosition().x, (int)GridPosition().y, currentBuilding);
        }
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

    private class Grid {
        private const Tile.TileType G = Tile.TileType.GRASS;
        private const Tile.TileType D = Tile.TileType.DEEP;
        private const Tile.TileType S = Tile.TileType.SAND;
        private const Tile.TileType R = Tile.TileType.ROCK;
        private const Tile.TileType W = Tile.TileType.WATER;

        private const int ROW = 10;
        private const int COL = 10;
        private readonly Tile.TileType[,] tileTypes =
            {{G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G},
            {G, G, G, G, G, G, G, G, G, G}};

        private Tile[,] gridData = new Tile[ROW, COL];


        private GameObject[] buildings;


        public Grid(GameObject[] g)
        {
            buildings = g;
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    setTile(i, j, tileTypes[i, j]);
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

       public void setBuilding(int row, int col, string bType) {
            if (row < 0 || col < 0 || row > 9 || col > 9)
                return;

            Debug.Log(row + ":" + col);

            switch (bType) {
                case "F":
                    Instantiate(buildings[0], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case "R":
                    Instantiate(buildings[1], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case "M":
                    Instantiate(buildings[2], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case "B":
                    Instantiate(buildings[3], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
            }
        }
    }

    public void buttonSelect(string type) {
        currentBuilding = type;
    }    
}