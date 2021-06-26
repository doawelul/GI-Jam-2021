using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public MapData map;

    public void StartMap(string s)
    {
        map.mapName = s;
        SceneManager.LoadScene(1);
    }
}