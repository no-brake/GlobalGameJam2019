using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloor : MonoBehaviour
{
    public Texture2D day1Floor;
    public Texture2D day2Floor;
    public Texture2D day3Floor;
    public Texture2D day4Floor;
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        switch(GlobalState.day)
        {
            case(1):
                rend.material.mainTexture = day1Floor; 
                break;
            case(2):    
                rend.material.mainTexture = day2Floor; 
                break;
            case(3):    
                rend.material.mainTexture = day3Floor; 
                break;
            case(4):    
                rend.material.mainTexture = day4Floor; 
                break;
             default:
                break;           
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
