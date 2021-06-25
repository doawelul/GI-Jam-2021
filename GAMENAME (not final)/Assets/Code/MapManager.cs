using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private int totalFood;
    private int totalStone;
    private int totalGold;
    
        
    private class Grid
    {
        private static readonly Tile.TileType G = Tile.TileType.GRASS;
        private static readonly Tile.TileType D = Tile.TileType.DEEP;
        private static readonly Tile.TileType S = Tile.TileType.SAND;
        private static readonly Tile.TileType R = Tile.TileType.ROCK;
        private static readonly Tile.TileType W = Tile.TileType.WATER;

private Tile.TileType[,] tiles = new Tile.TileType[,]
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





        private const int ROW = 10;
        private const int COL = 10;
        private Tile[,] gridData = new Tile[ROW, COL];

        public Grid()
        {
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    gridData[i, j] = new Tile(tiles[i,j]);
        }


        public Tile getTile(int row, int col)
        {
            return this.gridData[row, col];
        }

        public void setTile(int row, int col, Tile.TileType type) {
            this.gridData[row, col] = new Tile(type);
        }
    }

    

    void Start()
    {
        Grid layout = new Grid();
    }
}