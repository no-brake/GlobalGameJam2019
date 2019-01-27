using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{   
    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();
    }
    
    void OnDestroy()
    {
                if(gameState.houseHealth > 0 && GlobalState.day > 1) {
                    GlobalState.day--;
                } else if(gameState.houseHealth > 0 && GlobalState.day == 1) {
                    
                } else {
                    GlobalState.day++;
                }
                GlobalState.shownDay++;

                SceneManager.LoadScene("SampleScene");
    }
}
