﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Text text;

    public int kills;
    public float houseHealth;
    public int spawnCount;

    private Color alpha;
    public float timeToFade = 1.0f;
    public GameObject fadePlane;

    private Text dayText;

    private Color dayTextColor;

    // Start is called before the first frame update
    void Start()
    {
        this.kills = 0;
        this.houseHealth = 10;
        this.spawnCount = 0;

        //if (GlobalState.day <= 3) {
        alpha = fadePlane.GetComponent<MeshRenderer>().material.color;
        alpha.a = 0;
        dayText = fadePlane.GetComponentInChildren<Text>();
        dayText.text = "Day " + GlobalState.day;
        dayTextColor = dayText.color;
        dayTextColor.a = 0;
        //}


    }

    // Update is called once per frame
    void Update()
    {
        fadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadePlane.GetComponent<MeshRenderer>().material.color, alpha, timeToFade*Time.deltaTime);
        dayText.color = Color.Lerp(dayText.color, dayTextColor, timeToFade * Time.deltaTime * 2);

        if(this.houseHealth <= 0)
        {
            dayText.text = "Day " + (GlobalState.day + 1);
            dayTextColor.a = 1;
            alpha.a = 1;
            fadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadePlane.GetComponent<MeshRenderer>().material.color, alpha, timeToFade*Time.deltaTime);
            dayText.color = Color.Lerp(dayText.color,dayTextColor, timeToFade * Time.deltaTime * 2);
            Debug.Log("DayTextColor: " + dayText.color.a); 
            if(dayText.color.a > 0.9) {
                GlobalState.day++;
                List<Spawner> sMListe = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawners;
                if(GlobalState.day >= 2)
                {   
                    GameObject parent = GameObject.Find("Spawner");
                    Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
                    foreach(Transform t in trs){
                        if(t.name == "Spawner_Vert_Win7"){
                         sMListe.Add(t.gameObject.GetComponent<Spawner>());
                         print("active 1");
                        }
                    } 
                }
                if(GlobalState.day >= 3)
                {
                    GameObject parent = GameObject.Find("Spawner");
                    Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
                    foreach(Transform t in trs){
                        if(t.name == "Spawner_Hori_Win6"){
                         sMListe.Add(t.gameObject.GetComponent<Spawner>());
                         print("active 2");
                        }
                    } 
                }
                SceneManager.LoadScene("SampleScene");

            }
            //text.text = "DU BIST TOT!";
        }

    }
}
