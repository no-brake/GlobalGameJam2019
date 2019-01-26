using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Vector3 target;
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.Normalize(target - transform.position); 
        transform.position += speed * dir;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
