using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Vector3 startPlayer1;
    public Vector3 startPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        print(player1);
        print(player2);

        bool player1HasController = false;
        bool player2HasController = false;

        for(int i = 0; i < Mathf.Min(Input.GetJoystickNames().Length, 2); i++){
            bool v = false;
            if(Input.GetJoystickNames()[i].Length > 0){
                v = true;
            }
            switch(i){
                case 0:
                    player1HasController = v;
                    break;
                case 1:
                    player2HasController = v;
                    break;
            }
        }

        if(player1HasController && player2HasController) {
            GameObject p1 = Instantiate(player1, startPlayer1, Quaternion.identity);
            p1.GetComponent<Movement>().controller = 0;
            GameObject p2 = Instantiate(player2, startPlayer2, Quaternion.identity);
            p2.GetComponent<Movement>().controller = 1;
            // both use controller
        } else if(player1HasController) {
            GameObject p1 = Instantiate(player1, startPlayer1, Quaternion.identity);
            p1.GetComponent<Movement>().controller = 0;
        } else if(player2HasController) {
            GameObject p1 = Instantiate(player1, startPlayer1, Quaternion.identity);
            p1.GetComponent<Movement>().controller = 1;
        } else {
            // only one player plays the game
            GameObject p1 = Instantiate(player1, startPlayer1, Quaternion.identity);
            p1.GetComponent<Movement>().controller = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
