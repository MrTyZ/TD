using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameOver : MonoBehaviourPun
{
    public GameObject Map;
    private int count;
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
            switch(xuylo.name)
            {
                case "Enemy1U(Clone)":
                    {
                        count = 10;
                    }
                    break;
                case "Enemy2U(Clone)":
                    {
                        count = 10;
                    }
                    break;
                case "Enemy3U(Clone)":
                    {
                        count = 10;
                    }
                    break;
                case "Enemy4U(Clone)":
                    {
                        count = 10;
                    }
                    break;
                case "Enemy5U(Clone)":
                    {
                        count = 10;
                    }
                    break;
                case "Enemy1(Clone)":
                    {
                        count = 1;
                    }
                    break;
                case "Enemy2(Clone)":
                    {
                        count = 2;
                    }
                    break;
                case "Enemy3(Clone)":
                    {
                        count = 3;
                    }
                    break;
                case "Enemy4(Clone)":
                    {
                        count = 4;
                    }
                    break;
                case "Enemy5(Clone)":
                    {
                        count = 5;
                    }
                    break;
            }
            if (globalvariable.online) { photonView.RPC("DecreaseHealth", RpcTarget.All, count); }
            else { HealthBarFinal.realHeals -= count; }
            
            Destroy(xuylo.gameObject, .0f);
        }
    }
    [PunRPC]
    private void DecreaseHealth(int count)
    {
        HealthBarFinal.realHeals -= count;
    }
    IEnumerator GenMess()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }
}

