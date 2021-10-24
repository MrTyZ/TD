using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarFinal : MonoBehaviour
{

    public float maxHeals=100;
    public static float realHeals;
    void Start()
    {
       realHeals = maxHeals;
       GameObject.Find("HealthBarText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("health") + realHeals + " / " + maxHeals;
    }

     void Update()
    {
        if (realHeals >= 0)
        {
            //Изменение полоски здоровья
            GameObject.Find("HealthBarGreen").transform.localScale = new Vector3(realHeals,1);
            GameObject.Find("HealthBarText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("health") + realHeals + " / " + maxHeals;
        }
        
    }
}
