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
    private GameObject buildingSprite;

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

    public bool CanBuild()
    {
        if (groundType == TileType.DEEP || groundType == TileType.WATER)
            return false;
        return true;
    }

    public void setFarm(GameObject g)
    {
        buildingType = new Farm(groundType);
        buildingSprite = g;
    }

    public void setCastle(GameObject g)
    {
        buildingType = new Castle(groundType);
        buildingSprite = g;
    }

    public void setBank(GameObject g)
    {
        buildingType = new Bank(groundType);
        buildingSprite = g;
    }

    public void setMine(GameObject g)
    {
        buildingType = new Mine(groundType);
        buildingSprite = g;
    }

    public void setRoad(GameObject g)
    {
        this.buildingType = new Road(groundType);
        buildingSprite = g;
    }

    public int GetGoldChange()
    {
        return buildingType.yield().GetGold() - buildingType.upkeep().GetGold();
    }

    public int GetFoodChange()
    {
        return buildingType.yield().GetFood() - buildingType.upkeep().GetFood();
    }

    public int GetStoneChange()
    {
        return buildingType.yield().GetStone() - buildingType.upkeep().GetStone();
    }
}