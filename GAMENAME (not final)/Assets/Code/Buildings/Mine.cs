using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    private int hp;
    private readonly Tile.TileType tile;
    public Mine(Tile.TileType tile)
    {
        this.tile = tile;
        hp = 10;
    }
    public int getHp()
    {
        return hp;
    }
    public Resource upkeep()
    {
        return new Resource(4, Resource.ResourceType.GOLD);
    }
    public Resource yield()
    {
        if (tile == Tile.TileType.ROCK)
        {
            return new Resource(8, Resource.ResourceType.STONE);
        }
        else
        {
            return new Resource(5, Resource.ResourceType.STONE);
        }
    }
}