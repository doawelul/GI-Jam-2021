using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : Building
{
    private int hp;
    private Tile tile;
    public Road(Tile tile) {
        this.tile = tile;
        hp = 5;
    }
    public int getHp() {
        return hp;
    }
    public Resource upkeep() {
        return new Resource(3, Resource.ResourceType.WOOD);
    }
    public Resource yield() {
        return noResource();
    }

}