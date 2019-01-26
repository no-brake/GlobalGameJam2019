using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Watcher;
    public Enemy DeceasedPhantom;
    public Enemy Oriax;
    public GameObject target;
    float timeToSpawn;
    private GameState gameState; 
     
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 5F;
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {

        if(gameState.spawnCount == 50){
            Enemy ori = Instantiate(Oriax,transform.position + new Vector3(0,1,0),
                         Quaternion.LookRotation(-(transform.position + new Vector3(0,1,0)) + target.transform.position, new Vector3(0,1,0))); 
            ori.target = target.transform.position;
            ori.speed = 0.04F;
            ori.health = 1000;
            gameState.spawnCount++;
            return;
        }
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn <= 0 && gameState.spawnCount < 50)
        {  
            gameState.spawnCount++;  
            float scale = Mathf.Max(transform.localScale.x,transform.localScale.z);
            float ran   = Random.Range(-1.0F,1.0F);
            
            Vector3 pos = transform.position + ran * new Vector3(0,0,scale*5);
            Vector3 dir = -(pos + new Vector3(0,1,0)) + target.transform.position;
            if(ran < 0.75){
                Enemy watcher = Instantiate(Watcher,pos + new Vector3(0,1,0), Quaternion.LookRotation(dir, new Vector3(0,1,0))); 
                watcher.target = target.transform.position;
                watcher.speed = 0.1F;
                watcher.health = 100;
                timeToSpawn = 5F;
            }else{
                Enemy dPhan = Instantiate(DeceasedPhantom,pos + new Vector3(0,1,0), Quaternion.LookRotation(dir, new Vector3(0,1,0))); 
                dPhan.target = target.transform.position;
                dPhan.speed = 0.08F;
                dPhan.health = 500;
                timeToSpawn = 5F; 
            }

            
        }
    }
}
