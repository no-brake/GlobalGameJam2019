using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp : MonoBehaviour
{   
    public GameObject[] darkness;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {   
       if(col.GetComponent<Collider>().gameObject.tag == "Player")
       { 
            foreach(var d in darkness)
            {
                d.SetActive(false);
            }
       }    
    }

        void OnTriggerExit(Collider col)
    {   
    if(col.GetComponent<Collider>().gameObject.tag == "Player")
       { 
        foreach(var d in darkness)
        {
            d.SetActive(true);
        }
       }
    }
}
