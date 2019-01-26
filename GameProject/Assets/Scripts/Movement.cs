using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float transformSpeed = 10;
    public int rotationSpeed = 10;
    public int rotationOffset = 180;

    bool controllerConnected = false;

    // Start is called before the first frame update
    void Start()
    {   
        for (int i = 0; i < Input.GetJoystickNames().Length; i++){
            if (Input.GetJoystickNames()[i].Length > 0) {
                controllerConnected = true;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //-----Move the player
        float xLeft = Input.GetAxis("HorizontalLeft");
        float yLeft = Input.GetAxis("VerticalLeft");

        transform.Translate(new Vector3(xLeft * Time.deltaTime * transformSpeed , 0, -yLeft * Time.deltaTime * transformSpeed), Space.World);

        if(!controllerConnected) {
            //-----Rotate the player -> with Mouse
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Get the angle between the points
            float a = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            transform.rotation =  Quaternion.Euler (new Vector3(0f, -a + rotationOffset, 0f));
        } else {
            //-----Rotate the player -> with gamepad
            float xRight = Input.GetAxis("HorizontalRight");
            float yRight = Input.GetAxis("VerticalRight");

            if (xRight != 0.0f || yRight != 0.0f) {
                float angle = Mathf.Atan2(yRight, xRight) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, angle, 0f);
            }
        }

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
