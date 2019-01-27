using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Text text;

    public int kills;
    public float houseHealth;
    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        this.kills = 0;
        this.houseHealth = 10;
        this.spawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.houseHealth <= 0)
        {   
            GlobalState.day++;
            SceneManager.LoadScene("SampleScene");
            //text.text = "DU BIST TOT!";
        }
    }
}
