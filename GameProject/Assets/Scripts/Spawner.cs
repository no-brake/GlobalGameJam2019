using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy Enemy;
    float timeToSpawn; 
     
    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = 5F;
    }

    // Update is called once per frame
    void Update()
    {
       timeToSpawn -= Time.deltaTime;
       if(timeToSpawn <= 0)
       {    

           float scale = Mathf.Max(transform.localScale.x,transform.localScale.z);
           float ran = Random.Range(-1.0F,1.0F);
           Vector3 pos  = transform.position + ran * new Vector3(0,0,scale*5);
           Enemy enemy = Instantiate(Enemy,pos + new Vector3(0,1,0),Quaternion.identity);
           enemy.target = new Vector3(0,1,0);
           enemy.speed = 0.1F;
           timeToSpawn = 5F;
       }
    }
}
