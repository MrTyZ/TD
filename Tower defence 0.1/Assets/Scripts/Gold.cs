using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public static int gold_start = 100;
    public static int gold; // Глобальная переменная деньги
   
    private void Start()
    {
         gold = gold_start;
        GameObject.Find("GoldText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("gold") + gold.ToString();
    }
    void Update()
    {
        GameObject.Find("GoldText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("gold") + gold.ToString();
    }
    
    
   
}
