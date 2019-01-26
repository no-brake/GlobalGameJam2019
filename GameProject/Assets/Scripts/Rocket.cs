using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    public Explosion ex;
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

    void OnCollisionExit(Collision col)
    {
         Destroy(gameObject);
    }
    void OnDestroy()
    {
        Instantiate(ex,transform);
    }

}
