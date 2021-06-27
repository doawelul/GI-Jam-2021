using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Building
{
    private int hp;
    private readonly Tile.TileType tile;
    public static GameObject SPRITE;

    public Road(Tile.TileType tile)
    {
        this.tile = tile;
        hp = 5;
    }
    public int getHp()
    {
        return hp;
    }
    public Resource upkeep()
    {
        return new Resource(3, Resource.ResourceType.FOOD);
    }
    public Resource yield()
    {
        return Resource.noResource();
    }
}