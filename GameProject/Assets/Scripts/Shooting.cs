using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int bulletNum;
    bool canShoot;
    bool canShootThisFrame;
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

        if (this.canShootThisFrame) this.canShoot = true;

        if (Input.GetMouseButton(0) || Input.GetButton("Right Bumper" + controller))
        {
            if(canShoot && this.currentShotCooldown <= 0)
            {
                createBullet();

                this.currentShotCooldown = this.shotCooldown;
            }
        }

        if(Input.GetButtonDown("X" + controller))
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

        this.canShootThisFrame = false;

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
            canShootThisFrame = true;
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

        if (!controllerConnected)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            pos = mousePos - trans.position;
        } else {
            pos = trans.rotation * Vector3.right;
        }

        pos.y = 0;
        pos = Vector3.Normalize(pos);
        Vector3 bulletStartPos = trans.position + pos;
        bulletStartPos.y = 1.0f;

        Bullet bullet = Instantiate(Bullet, bulletStartPos, trans.rotation);
        bullet.dir = pos;
        bullet.speed = 0.6f;
        bullet.damage = 37;
        if(shotCooldown < 0.31 && shotCooldown > 0.29)
        {   
            print("Hallo Shotgun");
            float angle = 10 * Mathf.PI/180;
            Bullet bullet2 = Instantiate(Bullet, trans.position + pos, trans.rotation);
            bullet2.dir.x = Mathf.Cos(angle) * pos.x - Mathf.Sin(angle) * pos.z;
            bullet2.dir.z = Mathf.Sin(angle) * pos.x + Mathf.Cos(angle) * pos.z;
            bullet2.speed = 0.6f;
            bullet2.damage = 37;
            Bullet bullet3 = Instantiate(Bullet, trans.position + pos, trans.rotation);        
            bullet3.dir.x =  Mathf.Cos(-angle) * pos.x - Mathf.Sin(-angle) * pos.z;
            bullet3.dir.z =  Mathf.Sin(-angle) * pos.x + Mathf.Cos(-angle) * pos.z;
            bullet3.speed = 0.6f;
            bullet3.damage = 37;
        }
    }

    void createTrap()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(Trap, mousePos, Quaternion.identity);
    }
}
