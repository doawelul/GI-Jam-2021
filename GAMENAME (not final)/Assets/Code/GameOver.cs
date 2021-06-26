using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOver : MonoBehaviour
{
    public GameOverReason endReason;
    public Text gameOverMessage;


    // Start is called before the first frame update
    void Start()
    {
        gameOverMessage.text = endReason.reason;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
