using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NextWave : MonoBehaviour
{
   public static bool start = false;
    private void Start()
    {
        start = false;
        if ((!PhotonNetwork.IsMasterClient) && (globalvariable.online))
        { GameObject.Find("NextWave").SetActive(false); }
    }
    public void nextwave()
    {
        if (!start)
        { start=true; }
        else
        { 
          NewEnemy.wave = 20;
          NewEnemy.timerWave = 0;
          NewEnemy.a = false;
            Gold.gold += 20;
        }
    }
    void Update()
    {
        if (!MenuButtons.DebugMod)
        {
            if ((!PhotonNetwork.IsMasterClient) && (globalvariable.online))
            { }
            else
            {
                if ((NewEnemy.nextwave > 3) && (GameObject.Find("NextWave").GetComponent<RawImage>().enabled != true) && (NewEnemy.nextwave < 11))
                {
                    GameObject.Find("NextWave").GetComponent<RawImage>().enabled = true;
                    GameObject.Find("TextNextWave").GetComponent<Text>().enabled = true;
                }
                if (((NewEnemy.nextwave <= 3) || (NewEnemy.nextwave > 11)) && (GameObject.Find("NextWave").GetComponent<RawImage>().enabled == true) && (NewEnemy.FirstWave == true))
                {
                    GameObject.Find("NextWave").GetComponent<RawImage>().enabled = false;
                    GameObject.Find("TextNextWave").GetComponent<Text>().enabled = false;
                }
            }
        }
    }


}
