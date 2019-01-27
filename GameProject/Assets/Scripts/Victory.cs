using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{   
    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnDestroy()
    {
        gameState.text.color = Color.green;
        gameState.text.text = "Du bist Kacke!";
    }
}
