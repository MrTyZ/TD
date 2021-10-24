using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLoaderUI : MonoBehaviour
{

    public string key = "comingsoon";
    string value;
    public static bool swap = false;

    public void Start()
    {
        value = localisationSystem.GetLocalisedValue(key);
        gameObject.GetComponent<Text>().text = "";
        gameObject.GetComponent<Text>().text = value;
        value = null;
    }
    public void Update()
    {
        if (swap == true)
        {
            value = localisationSystem.GetLocalisedValue(key);
            gameObject.GetComponent<Text>().text = "";
            gameObject.GetComponent<Text>().text = value;
            value = null;
        }
    }
   
}
