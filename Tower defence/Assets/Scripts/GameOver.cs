using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject Map;
    
    void Update()
    {
        if (HealthBarFinal.realHeals <= 0)  //Действия после проигрыша
        {
            if (PlayerPrefs.GetInt("maxwave") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave", NewEnemy.Wave); }

            Map = GameObject.FindGameObjectWithTag("map");
            switch (Map.name)
            {
                case "Map1":
                    { if (PlayerPrefs.GetInt("maxwave1") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave1", NewEnemy.Wave); } }
                    break;
                case "Map2":
                    { if (PlayerPrefs.GetInt("maxwave2") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave2", NewEnemy.Wave); } }
                    break;
                case "Map3":
                    { if (PlayerPrefs.GetInt("maxwave3") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave3", NewEnemy.Wave); } }
                    break;
                case "Map4":
                    { if (PlayerPrefs.GetInt("maxwave4") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave4", NewEnemy.Wave); } }
                    break;
                case "Map5":
                    { if (PlayerPrefs.GetInt("maxwave5") < NewEnemy.Wave) { PlayerPrefs.SetInt("maxwave5", NewEnemy.Wave); } }
                    break;
            }
                


            GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("gameover") + NewEnemy.Wave;
           GameObject.Find("BlackGame").GetComponent<Image>().enabled = true;
           GameObject.Find("Main text").GetComponent<Text>().color = new Color(251, 0, 20);
            StartCoroutine(GenMess());
        }

    }
   
    public void OnTriggerEnter(Collider xuylo) 
    {
        if (xuylo.tag == "Enemy")//Отнимание здоровья при пропуске врага
        {
            HealthBarFinal.realHeals -= 1;
            Destroy(xuylo.gameObject, .0f);
        }
    }
    IEnumerator GenMess()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
}

