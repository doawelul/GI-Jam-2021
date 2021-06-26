using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour, Building
{
    private int hp;
    private readonly Tile.TileType tile;
    public Bank(Tile.TileType tile) {
        this.tile = tile;
        hp = 7;
    }
    public int getHp() {
        return hp;
    }
    public Resource upkeep() {
        return new Resource(5, Resource.ResourceType.GOLD);
    }
    public Resource yield() {
        return new Resource(10, Resource.ResourceType.GOLD);
    }
}