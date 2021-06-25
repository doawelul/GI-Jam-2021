using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private int totalFood;
    private int totalStone;
    private int totalGold;

    public GameObject[] tileTypes;

    private class Grid
    {
        private static readonly Tile.TileType G = Tile.TileType.GRASS;
        private static readonly Tile.TileType D = Tile.TileType.DEEP;
        private static readonly Tile.TileType S = Tile.TileType.SAND;
        private static readonly Tile.TileType R = Tile.TileType.ROCK;
        private static readonly Tile.TileType W = Tile.TileType.WATER;

        private const int ROW = 10;
        private const int COL = 10;
        private Tile.TileType[,] tiles = new Tile.TileType[ROW, COL]
            { {G, G, G, G, G, G, G, G, G, G},
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
        private GameObject[] tileTypes;

        public Grid(GameObject[] g)
        {
            tileTypes = g;

            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                {
                    setTile(i, j, tiles[i, j]);
                }
        }

        public Tile getTile(int row, int col)
        {
            return this.gridData[row, col];
        }

        public void setTile(int row, int col, Tile.TileType type)
        {
            this.gridData[row, col] = new Tile(type, getSprite(row, col, type));
        }

        private GameObject getSprite(int row, int col, Tile.TileType type)
        {
            //can probably do without switch, but just wanted to make it work
            switch (type)
            {
                case Tile.TileType.DEEP:
                    Instantiate(tileTypes[0], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case Tile.TileType.WATER:
                    Instantiate(tileTypes[1], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case Tile.TileType.ROCK:
                    Instantiate(tileTypes[2], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case Tile.TileType.GRASS:
                    Instantiate(tileTypes[3], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
                case Tile.TileType.SAND:
                    Instantiate(tileTypes[4], new Vector2(row, col), new Quaternion(0, 0, 0, 0));
                    break;
            }
            return null;
        }
    }


    private void Start()
    {
        Grid layout = new Grid(tileTypes);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log(GridPosistion());
    }

    private Vector2 GridPosistion()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = 10.0F;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        return new Vector2((int) (v3.x + 0.5F), (int)(v3.y + 0.5F));
    }
}