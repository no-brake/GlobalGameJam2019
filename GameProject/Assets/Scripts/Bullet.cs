using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   

    public float speed;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
         Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
      transform.position += speed * dir; 
    }

        void OnTriggerEnter (Collider col)
    {   
        
        if(col.GetComponent<Collider>().gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(col.GetComponent<Collider>().gameObject);
        }   
    }

    void OnCollisionExit(Collision col)
    {
/*          if(col.gameObject.tag == "Enemy")
         {
             Destroy(gameObject);
             Destroy(col.gameObject);
         }
         else  */if(col.gameObject.tag == "Wall")
        {
            print("Hit the wall");
            Destroy(gameObject);
        }
    }
}