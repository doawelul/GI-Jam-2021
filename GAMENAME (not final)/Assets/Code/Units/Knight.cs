using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour, Unit
{

    private const int MOVE_SPEED = 1;
    private const int BASE_DAMAGE = 1;
    private const int ACTIONS_PER_TURN = 2;
    private int hp;
    private int row;
    private int col;
    private int actions;
    private bool dead;
    public Knight(int row, int col)
    {
        this.hp = 5;
        this.row = row;
        this.col = col;
        this.actions = ACTIONS_PER_TURN;
        dead = false;
    }
    public int getHp()
    {
        return hp;
    }

    public int getMoveSpd()
    {
        return MOVE_SPEED;
    }
    public Resource upkeep()
    {
        return new Resource(5, Resource.ResourceType.GOLD);
    }
    public int getDmg(Unit target)
    {
        //if(target.GetType() == typeof(Bandit)) {
        //    return BASE_DAMAGE * 2;
        //} else {
        return BASE_DAMAGE;
        //}
    }
    public int getRow()
    {
        return row;
    }
    public int getCol()
    {
        return col;
    }
    public int getRemainingActions()
    {
        return actions;
    }
    public void refreshActions()
    {
        actions = ACTIONS_PER_TURN;
    }
    public void takeDmg(int amt)
    {
        hp -= amt;
        if (hp <= 0)
        {
            dead = true;
        }
    }
    public bool isDead()
    {
        return dead;
    }
    public void move(int newRow, int newCol)
    {
        row = newRow;
        col = newCol;
    }
}