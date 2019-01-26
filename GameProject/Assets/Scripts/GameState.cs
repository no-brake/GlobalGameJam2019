using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Text text;

    public int kills;
    public float houseHealth;

    // Start is called before the first frame update
    void Start()
    {
        this.kills = 0;
        this.houseHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.houseHealth <= 0)
        {
            text.text = "DU TOT";
        }
    }
}
