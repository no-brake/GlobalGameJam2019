using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicDay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Text textComponent = this.GetComponent<Text>();
        textComponent.text = "Day " + GlobalState.day;
    }
}
