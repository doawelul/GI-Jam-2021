using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public enum ResourceType
    {
        FOOD,
        STONE,
        GOLD,
        NULL
    }
    private int amt;
    private ResourceType type;

    public Resource(int amt, ResourceType type)
    {
        this.amt = amt;
        this.type = type;
    }

    public static Resource noResource()
    {
        return new Resource(0, ResourceType.NULL);
    }

    public int GetGold()
    {
        return type == ResourceType.GOLD ? amt : 0;
    }

    public int GetFood()
    {
        return type == ResourceType.FOOD ? amt : 0;
    }

    public int GetStone()
    {
        return type == ResourceType.STONE ? amt : 0;
    }
}