using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType
    {
        DEEP,
        WATER,
        ROCK,
        GRASS,
        SAND
    }

    public static bool SPRITES_LOADED = false;
    public static GameObject DEEP_SPRITE;
    public static GameObject WATER_SPRITE;
    public static GameObject ROCK_SPRITE;
    public static GameObject GRASS_SPRITE;
    public static GameObject SAND_SPRITE;

    private TileType groundType;
    private Building buildingType;
    private GameObject tileSprite;

    public Tile(TileType type)
    {
        groundType = type;
        buildingType = null;
    }

    public static GameObject createGameTile(int row, int col, Tile tile)
    {
        GameObject sprite = null;
        switch (tile.getGroundType())
        {
            case Tile.TileType.DEEP:
                sprite = DEEP_SPRITE;
                break;
            case Tile.TileType.WATER:
                sprite = WATER_SPRITE;
                break;
            case Tile.TileType.ROCK:
                sprite = ROCK_SPRITE;
                break;
            case Tile.TileType.GRASS:
                sprite = GRASS_SPRITE;
                break;
            case Tile.TileType.SAND:
                sprite = SAND_SPRITE;
                break;
        }
        return Instantiate(sprite, new Vector2(row, col), new Quaternion(0, 0, 0, 0));
    }

    public TileType getGroundType()
    {
        return groundType;
    }

    public Building getBuilding()
    {
        return buildingType;
    }

    public void setFarm()
    {
        buildingType = new Farm(groundType);
    }

    public void setCastle()
    {
        buildingType = new Castle(groundType);
    }

    public void setBank()
    {
        buildingType = new Bank(groundType);
    }

    public void setMine()
    {
        buildingType = new Mine(groundType);
    }

    public void setRoad()
    {
        this.buildingType = new Road(groundType);
    }
}