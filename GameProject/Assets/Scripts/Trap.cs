using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap: MonoBehaviour
{
    public float trapTime;
    public Texture2D phantom;
    public Texture2D bossMoss;
    private Texture2D oldTexture;
    GameObject eminem;
    float oldSpeed;
    Renderer rend;
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
                rend.material.mainTexture = oldTexture;
                eminem.GetComponent<Enemy>().speed= oldSpeed;
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
               
                rend = eminem.GetComponentsInChildren<Renderer>()[0];
                oldTexture = (Texture2D)rend.material.mainTexture;
                rend.material.mainTexture = phantom;
            }    
        }
    }
}
