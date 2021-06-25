using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    private int hp;
    private readonly Tile tile;
    private readonly string owner;
    public Road(Tile tile, string owner) {
        this.tile = tile;
        this.owner = owner;
        hp = 10;
    }
    public int getHp() {
        return hp;
    }
    public Resource upkeep() {
        return new Resource(4, Resource.ResourceType.GOLD);
    }
    public Resource yield() {
        if(tile.getType() == 'S') {
            return new Resource(8, Resource.ResourceType.STONE);
        } else {
            return new Resource(5, Resource.ResourceType.STONE);
        }
    }
    public string owner() {
        return owner;
    }
}