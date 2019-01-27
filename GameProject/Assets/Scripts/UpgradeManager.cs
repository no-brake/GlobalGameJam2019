using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private GameState gameState;
    private GameObject[]  weaponSpots;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameStateObject = GameObject.Find("GameState");
        this.gameState = gameStateObject.GetComponent<GameState>(); 
        weaponSpots = GameObject.FindGameObjectsWithTag("WeaponSpot");
        foreach(var w in weaponSpots) w.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        print(2 * (int) weaponSpots[0].GetComponent<WeaponSpot>().weapon);
        for(int i = 0; i< weaponSpots.Length; i++)
        {   WeaponTypes weap = weaponSpots[i].GetComponent<WeaponSpot>().weapon;
            switch(weap)
            {
                case WeaponTypes.Shotgun:
                    if(gameState.kills >= 17)
                    {
                        weaponSpots[i].SetActive(true);
                    }
                    break;
                case WeaponTypes.Rifle:
                    if(gameState.kills >= 32)
                    {
                        weaponSpots[i].SetActive(true);
                    }
                    break;  
                default:
                    break;    
            }
        }    
    }
}
