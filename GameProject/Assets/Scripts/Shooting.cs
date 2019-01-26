using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int x, y;
    float cooldown;
    int bulletNum;
    public Bullet Bullet;
    bool canShoot;

    bool controllerConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++){
            if (Input.GetJoystickNames()[i].Length > 0) {
                controllerConnected = true;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot) {
            Transform trans = this.gameObject.transform;
            Vector3 pos = new Vector3();
            bool shoot = false;

            if (!controllerConnected) {
                if((Input.GetMouseButton(0))) 
                {
                    Vector3 mousePos = Input.mousePosition ;
                    mousePos.z = 20;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                    pos = mousePos - trans.position;
                    pos.y = 0;
                    shoot = true;
                }
            } else {
                bool trigger = Input.GetButton("Right Bumper");
                if(trigger) {
                    shoot = true;
                    pos = trans.rotation * Vector3.right;
                    pos.y = 0;
                }
            }
            if (shoot) {
                pos = Vector3.Normalize(pos);
                Bullet bullet = Instantiate(Bullet, trans.position + pos, trans.rotation);
                bullet.dir = pos;
                bullet.speed = 0.8f;
            }
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
}
