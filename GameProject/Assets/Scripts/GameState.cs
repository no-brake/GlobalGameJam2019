using System.Collections;
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
        dayText.text = "Day " + GlobalState.shownDay;
        dayTextColor = dayText.color;
        dayTextColor.a = 0;
        List<Spawner> sMListe = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().spawners;
        print(sMListe.Count);
        if(GlobalState.day == 1){
            GameObject.Find("lightAreaDay2").SetActive(false);
        }
        if(GlobalState.day <=2 ){
            GameObject.Find("lightAreaDay3").SetActive(false);
        }

        if(GlobalState.day == 2)
            {   
                GameObject parent = GameObject.Find("Spawner");
                Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
                foreach(Transform t in trs){
                    if(t.name == "Spawner_Vert_Win7")
                    {
                        sMListe.Add(t.gameObject.GetComponent<Spawner>());
                    }
                } 
            }
            if(GlobalState.day == 3)
            {
                GameObject parent = GameObject.Find("Spawner");
                Transform[] trs= parent.GetComponentsInChildren<Transform>(true);
                foreach(Transform t in trs){
                   if(t.name == "Spawner_Hori_Win6")
                   {
                     sMListe.Add(t.gameObject.GetComponent<Spawner>());
                    }
                } 
            }
    }

    // Update is called once per frame
    void Update()
    {
        fadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadePlane.GetComponent<MeshRenderer>().material.color, alpha, timeToFade*Time.deltaTime);
        dayText.color = Color.Lerp(dayText.color, dayTextColor, timeToFade * Time.deltaTime * 2);

        if(this.houseHealth <= 0)
        {
            if(GlobalState.day < 4) {
                dayText.text = "Day " + (GlobalState.shownDay + 1);
                dayTextColor.a = 1;
                alpha.a = 1;
                fadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadePlane.GetComponent<MeshRenderer>().material.color, alpha, timeToFade*Time.deltaTime);
                dayText.color = Color.Lerp(dayText.color,dayTextColor, timeToFade * Time.deltaTime * 2);
                Debug.Log("DayTextColor: " + dayText.color.a);

                if(dayText.color.a > 0.9) {
                GlobalState.day++;
                GlobalState.shownDay++;

                SceneManager.LoadScene("SampleScene");
                }
            } else {
                //TODO: RESET EVERY VARIABLE NECESSARY!!
                GlobalState.day = 1;
                GlobalState.shownDay = 1;
                //FADE IN GAME OVER SCREEN
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
}
