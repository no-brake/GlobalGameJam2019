using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Vector3 target;
    public float speed;
    public int health;
    public float houseHealthDamageValue = 5;

    public float timeToDmg = 2.0f;
    private float currentTimeToDmg;
    private bool isAtWindow = false;

    private GameState gameState;

    // Start is called before the first frame update

    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();

        this.currentTimeToDmg = this.timeToDmg;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if(gameState)
            {
                gameState.kills++;
                print("Kills: " + gameState.kills);
            }

            Destroy(gameObject);
        }

        if((transform.position - target).magnitude <= 0.05)
        {
            if(gameState)
            {
                this.isAtWindow = true;
            }
        } else
        {
            Vector3 dir = Vector3.Normalize(target - transform.position);
            transform.position += speed * dir;
        }

        if (this.isAtWindow)
        {
            this.currentTimeToDmg -= Time.deltaTime;
            if (this.currentTimeToDmg < 0)
            {
                gameState.houseHealth -= houseHealthDamageValue;
                print("house health: " + gameState.houseHealth);
                
                Destroy(gameObject);
            }
        }
    }
}
