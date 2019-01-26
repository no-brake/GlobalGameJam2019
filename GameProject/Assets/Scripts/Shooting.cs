using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int bulletNum;
    bool canShoot;
    bool controllerConnected = false;

    public Bullet Bullet;
    public Trap Trap;
    public float shotCooldown = 0.5f;
    int controller;

    float currentShotCooldown;

    // Start is called before the first frame update
    void Start()
    {
        Movement myScript = this.GetComponentInParent<Movement>();
        controller = myScript.controller;
        if(Input.GetJoystickNames().Length > 0){
            if (Input.GetJoystickNames()[controller].Length > 0) {
                controllerConnected = true;
            }
        }

        this.currentShotCooldown = this.shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentShotCooldown -= Time.deltaTime;

<<<<<<< HEAD
        if (Input.GetMouseButton(0) || Input.GetButton("Right Bumper0"))
=======
        if (Input.GetMouseButton(0) || Input.GetButton("Right Bumper" + controller))
>>>>>>> 9da3d40ef03ae70ceec71541f38ab8b66fe96be8
        {
            if(canShoot && this.currentShotCooldown <= 0)
            {
                createBullet();

                this.currentShotCooldown = this.shotCooldown;
            }
        }

<<<<<<< HEAD
        if(Input.GetButtonDown("X0"))
=======
        if(Input.GetButtonDown("X" + controller))
>>>>>>> 9da3d40ef03ae70ceec71541f38ab8b66fe96be8
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

        if(Input.GetMouseButtonDown(1))
        {
            createTrap();
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().gameObject.tag == "shootArea")
        {   
            print("you can  shoot");
            canShoot = true;
        }
        if(col.GetComponent<Collider>().gameObject.tag == "WeaponSpot")
        {   
            print("Maschine Gun");
            this.shotCooldown = col.GetComponent<Collider>().gameObject.GetComponent<WeaponSpot>().wcooldown;
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

    void createTrap()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(Trap, mousePos, Quaternion.identity);
    }
}
