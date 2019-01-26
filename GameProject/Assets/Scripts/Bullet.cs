using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float speed;
    public Vector3 dir;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos += speed * dir;
        pos.y = 1.0f;
        this.transform.position = pos;
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.GetComponent<Collider>().gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            col.GetComponent<Collider>().gameObject.GetComponent<Enemy>().health -= damage;
        }
    }

    void OnCollisionExit(Collision col)
    {
        /*          if(col.gameObject.tag == "Enemy")
                 {
                     Destroy(gameObject);
                     Destroy(col.gameObject);
                 }
                 else  */
        if (col.gameObject.tag == "Wall")
        {
            //print("Hit the wall");
            Destroy(gameObject);
        }
    }
}