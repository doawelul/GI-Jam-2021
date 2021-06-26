using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public enum ResourceType {
        WOOD,
        STONE,
        GOLD
    }
    private int amt;
    private ResourceType type;

    public Resource(int amt, ResourceType type) {
        this.amt = amt;
        this.type = type;
    }

    public static Resource noResource() {
        return new Resource(0, ResourceType.WOOD);
    }
}