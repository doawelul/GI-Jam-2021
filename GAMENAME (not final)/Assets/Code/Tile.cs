using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    private char groundType;
    private Building buildingType;

    public Tile(char name) {
        groundType = name;
        buildingType = null;
    }

    public char getGroundType() {
        return groundType;
    }

    public Building getBuilding() {
        return this.buildingType;
    }

    public void setBuilding(char name) {
        this.buildingType = new Building();
    }
 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
