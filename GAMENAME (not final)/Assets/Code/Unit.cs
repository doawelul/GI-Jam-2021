using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Unit
{
    int getHp();
    int getMoveSpd();
    Resource upkeep();
    int getDmg(Unit target);
    int getRow();
    int getCol();
    int getRemainingActions();
    void refreshActions();
    void takeDmg(int amt);
    bool isDead();
    void move(int newRow, int newCol);
}