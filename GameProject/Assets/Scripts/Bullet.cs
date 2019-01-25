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
        Destroy(gameObject);
        print ("Player collided with" + col.GetComponent<Collider>().gameObject.name);
    }
}