using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int bulletNum;
    bool canShoot;
    bool controllerConnected = false;

    public Bullet Bullet;
    public float shotCooldown = 0.5f;
    float currentShotCooldown;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++){
            if (Input.GetJoystickNames()[i].Length > 0) {           
                controllerConnected = true;
                break;
            }
        }

        this.currentShotCooldown = this.shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentShotCooldown -= Time.deltaTime;

        if (Input.GetMouseButton(0) || Input.GetButton("Right Bumper"))
        {
            if(canShoot && this.currentShotCooldown <= 0)
            {
                createBullet();

                this.currentShotCooldown = this.shotCooldown;
            }
        }

        if(Input.GetButtonDown("X"))
        {
            print("Mashine!!");
            if(this.shotCooldown == 0.5)
            {
                this.shotCooldown = 0.05f;
            } else
            {
                this.shotCooldown = 0.5f;
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

    void createBullet()
    {
        Transform trans = this.gameObject.transform;
        Vector3 pos = new Vector3();

        if (!controllerConnected) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            pos = mousePos - trans.position;
        } else {
            pos = trans.rotation * Vector3.right;
        }

        pos.y = 0;
        pos = Vector3.Normalize(pos);

        Bullet bullet = Instantiate(Bullet, trans.position + pos, trans.rotation);
        bullet.dir = pos;
        bullet.speed = 0.6f;
        bullet.damage = 37;
    }
}
