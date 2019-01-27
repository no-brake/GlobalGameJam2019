using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int bulletNum;
    bool canShoot;
    bool canShootThisFrame;
    bool controllerConnected = false;

    WeaponTypes selectedWeapon = WeaponTypes.Pistol;

    public Bullet Bullet;
    public Bullet specialBullet;
    public Trap Trap;
    float shotCooldown;
    int controller;

    float currentShotCooldown;

    GameObject walls;


    float GetWeaponCooldownTime(WeaponTypes weapon)
    {
        switch (weapon)
        {
            case WeaponTypes.Pistol: return 0.5f;
            case WeaponTypes.Rifle: return 0.05f;
            case WeaponTypes.Shotgun: return 0.8f;
            case WeaponTypes.Special_Gun: return 0.3f;
            case WeaponTypes.ROCKET_LAUNCHER: return 1f;
            case WeaponTypes.SUPER_WEAPON: return 0.05f;
            default: return 0.5f;
        }
    }

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

        this.shotCooldown = GetWeaponCooldownTime(this.selectedWeapon);
        this.currentShotCooldown = this.shotCooldown;
        this.canShoot = true;

        walls = GameObject.Find("Walls");
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

        this.canShootThisFrame = false;

        if(Input.GetMouseButtonDown(1))
        {
            createTrap();
        }

        if(Input.GetKeyDown("u"))
        {
            this.selectedWeapon = WeaponTypes.Special_Gun;
        }
        if(Input.GetKeyDown("n"))
        {
            this.selectedWeapon = WeaponTypes.SUPER_WEAPON;
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

        if(col.GetComponent<Collider>().gameObject.tag == "Door")
        {
            walls.SetActive(!walls.activeSelf);
        }

        if(col.GetComponent<Collider>().gameObject.name == "SpotRifle")
        {   
            print("Rifle");
            this.selectedWeapon = WeaponTypes.Rifle;
            this.shotCooldown = GetWeaponCooldownTime(this.selectedWeapon);
        }
        if(col.GetComponent<Collider>().gameObject.name == "SpotShotgun")
        {
            print("shotgun");
            this.selectedWeapon = WeaponTypes.Shotgun;
            this.shotCooldown = GetWeaponCooldownTime(this.selectedWeapon);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.GetComponent<Collider>().gameObject.tag == "shootArea")
        {   
            print("you can't shoot");
            //canShoot = false;
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

        Bullet bullet;
        if (this.selectedWeapon == WeaponTypes.Special_Gun || this.selectedWeapon == WeaponTypes.SUPER_WEAPON)
        {
            bullet = Instantiate(specialBullet, bulletStartPos, trans.rotation);
        }
        else
        {
            bullet = Instantiate(Bullet, bulletStartPos, trans.rotation);
        }

        bullet.dir = pos;
        bullet.speed = 0.6f;
        bullet.damage = 37;

        if(this.selectedWeapon == WeaponTypes.Shotgun || this.selectedWeapon == WeaponTypes.SUPER_WEAPON)
        {
            bullet.damage = 120;
            for(int i = 0; i < 10; i++){
                if(i==5)continue;
                float angle = (10- 2*i) * Mathf.PI/180;
                Bullet bullet2 = Instantiate(Bullet, trans.position + pos, trans.rotation);
                bullet2.dir.x = Mathf.Cos(angle) * pos.x - Mathf.Sin(angle) * pos.z;
                bullet2.dir.z = Mathf.Sin(angle) * pos.x + Mathf.Cos(angle) * pos.z;
                bullet2.speed = 0.6f - Random.Range(0.0f,0.5f);
                bullet2.damage = 80;
                Destroy(bullet2, 1f);
                // Bullet bullet3 = Instantiate(Bullet, trans.position + pos, trans.rotation);
                // bullet3.dir.x =  Mathf.Cos(-angle) * pos.x - Mathf.Sin(-angle) * pos.z;
                // bullet3.dir.z =  Mathf.Sin(-angle) * pos.x + Mathf.Cos(-angle) * pos.z;
                // bullet3.speed = 0.6f;
                // bullet3.damage = 80;
            }
        }

        if (this.selectedWeapon == WeaponTypes.Special_Gun)
        {
            bullet.speed = 0.4f;
            bullet.damage = 135;
        }
    }

    void SpecialShot()
    {
        Transform trans = this.gameObject.transform;
        Vector3 pos = new Vector3();

        if (!controllerConnected)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            pos = mousePos - trans.position;
        }
        else
        {
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
        if (this.selectedWeapon == WeaponTypes.Shotgun)
        {
            bullet.damage = 120;
            float angle = 10 * Mathf.PI / 180;
            Bullet bullet2 = Instantiate(Bullet, trans.position + pos, trans.rotation);
            bullet2.dir.x = Mathf.Cos(angle) * pos.x - Mathf.Sin(angle) * pos.z;
            bullet2.dir.z = Mathf.Sin(angle) * pos.x + Mathf.Cos(angle) * pos.z;
            bullet2.speed = 0.6f;
            bullet2.damage = 80;
            Bullet bullet3 = Instantiate(Bullet, trans.position + pos, trans.rotation);
            bullet3.dir.x = Mathf.Cos(-angle) * pos.x - Mathf.Sin(-angle) * pos.z;
            bullet3.dir.z = Mathf.Sin(-angle) * pos.x + Mathf.Cos(-angle) * pos.z;
            bullet3.speed = 0.6f;
            bullet3.damage = 80;
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
