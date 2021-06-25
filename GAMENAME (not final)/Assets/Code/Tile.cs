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
    private TileType groundType;
    private Building buildingType;
    private GameObject tileSprite;

    public Tile(TileType type, GameObject sprite)
    {
        groundType = type;
        tileSprite = sprite;
        buildingType = null;
    }

    public TileType getGroundType()
    {
        return groundType;
    }

    public Building getBuilding()
    {
        return this.buildingType;
    }

    public void setFarm()
    {
        this.buildingType = new Farm(groundType);
    }

    public void setCastle()
    {
        this.buildingType = new Castle(groundType);
    }

    public void setBank()
    {
        this.buildingType = new Bank(groundType);
    }

    public void setMine()
    {
        this.buildingType = new Mine(groundType);
    }

    public void setRoad()
    {
        this.buildingType = new Road(groundType);
    }
}