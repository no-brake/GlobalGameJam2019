using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ParticleSystem part;
    // Start is called before the first frame update
    public int damage;

    void Start()
    {
       Explode(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1,1,1);
    }
    void Explode() {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
    }
}
