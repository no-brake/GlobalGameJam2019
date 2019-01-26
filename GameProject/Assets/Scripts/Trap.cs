using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap: MonoBehaviour
{
    public float trapTime;
    GameObject eminem;
    float oldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(eminem != null)
        {
            trapTime -= Time.deltaTime;
            if(trapTime <= 0)
            {
                eminem.GetComponent<Enemy>().speed = oldSpeed;
                trapTime = 3; 
                Destroy(gameObject);
            }
        }
        
    }

    void OnTriggerEnter(Collider col)
    {   
        print("Trapped");
        if(col.GetComponent<Collider>().gameObject.tag == "Enemy")
        {   
            print("Trapped Enemy");
                
            if(eminem == null && col.GetComponent<Collider>().gameObject.GetComponent<Trapable>())
            {
                eminem  = col.GetComponent<Collider>().gameObject;
                oldSpeed = eminem.GetComponent<Enemy>().speed;
                eminem.GetComponent<Enemy>().speed = 0;
            }    
        }
    }
}
