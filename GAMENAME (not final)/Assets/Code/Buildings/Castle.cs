using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Building
{
    private int hp;
    private readonly Tile.TileType tile;
    public static GameObject SPRITE;

    public Castle(Tile.TileType tile)
    {
        this.tile = tile;
        hp = 20;
    }
    public int getHp()
    {
        return hp;
    }
    public Resource upkeep()
    {
        return new Resource(7, Resource.ResourceType.GOLD);
    }
    public Resource yield()
    {
        return Resource.noResource();
    }
}
