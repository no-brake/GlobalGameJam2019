﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float speed;
    public Vector3 dir;
    public int damage;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        if (audioData)
        {
            audioData.Play(0);
        }
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            //print("Hit the wall");
            Destroy(gameObject);
        }
    }
}