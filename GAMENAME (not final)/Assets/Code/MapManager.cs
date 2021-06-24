using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private class Grid
    {
        private const int ROW = 5;
        private const int COL = 5;
        private Tile[,] gridData = new Tile[ROW, COL];

        public Grid()
        {
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    gridData[i, j] = new Tile("Grass");
        }

        public Tile getTile(int row, int col)
        {
            return this.gridData[row, col];
        }
    }

    private class Tile
    {
        private string groundType;
        private Building buildingType;

        public Tile(string name)
        {
            groundType = name;
            buildingType = null;
        }
    }

    void Start()
    {
        
    }
}