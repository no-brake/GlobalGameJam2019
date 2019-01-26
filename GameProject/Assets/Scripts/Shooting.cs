using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int x, y;
    float cooldown;
    int bulletNum;
    public Bullet Bullet;
    bool canShoot, isShooting;
    int frequence;
    // Start is called before the first frame update
    void Start()
    {
        frequence = 25;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)  && canShoot) 
       {
            createBullet();
            isShooting = true;
       }   
       if(Input.GetMouseButtonUp(0))
       {
           isShooting = false;
       }
       if(isShooting && canShoot &&  Time.frameCount % frequence == 0)
       {
           createBullet();
       }
    }


    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().gameObject.tag == "shootArea")
        {   
            print("you can  shoot");
            canShoot = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
         if(col.GetComponent<Collider>().gameObject.tag == "shootArea")
        {   
            print("you can't shoot");
            canShoot = false;
        }
    }

    void  createBullet()
    {
        Vector3 mousePos = Input.mousePosition ;
           
        mousePos.z = 20;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        Transform trans = this.gameObject.transform;

        Vector3 pos = mousePos - trans.position;
        pos.y = 0;
        pos = Vector3.Normalize(pos);
        Bullet bullet = Instantiate(Bullet,trans.position + pos,trans.rotation);
        bullet.speed = 0.6F;
        bullet.dir = pos;
        bullet.damage = 37;
    }
}
