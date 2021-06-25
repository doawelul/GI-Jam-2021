using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Building : MonoBehaviour
{
    int getHp();
    Resource upkeep();
    Resource yield();
}