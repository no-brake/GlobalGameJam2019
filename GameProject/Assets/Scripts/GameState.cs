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

        if(this.houseHealth <= 9)
        {
            if(GlobalState.day < 4) {
                dayText.text = "Day " + (GlobalState.day + 1);
                dayTextColor.a = 1;
                alpha.a = 1;
                fadePlane.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadePlane.GetComponent<MeshRenderer>().material.color, alpha, timeToFade*Time.deltaTime);
                dayText.color = Color.Lerp(dayText.color,dayTextColor, timeToFade * Time.deltaTime * 2);
                Debug.Log("DayTextColor: " + dayText.color.a);

                if(dayText.color.a > 0.9) {
                GlobalState.day++;
                SceneManager.LoadScene("SampleScene");
                }
            } else {
                //FADE IN GAME OVER SCREEN
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
}
