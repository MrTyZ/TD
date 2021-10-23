using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class StartScene : MonoBehaviour
{
    public static GameObject[] MapArray = new GameObject[MenuButtons.countmap];
    public static GameObject GameMenu;
    void Start()
    {
        if ((SceneManager.GetActiveScene().name == "Main1") || (SceneManager.GetActiveScene().name == "MainMultiplayer"))
        {



            for (int i = 0; i < MenuButtons.countmap; i++)
            {
                MapArray[i] = GameObject.Find(MenuButtons.MapArrayString[i]);
                MapArray[i].SetActive(false);
            }
            MapArray[MenuButtons.SelectArray].SetActive(true);
        }
        GameMenu = GameObject.Find("GameMenu");
        GameMenu.SetActive(false);
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "MainMultiplayer")
        {
            GameObject.Find("log").GetComponent<Text>().text += "Online " + globalvariable.online + "\n";
        }

        if (!PhotonNetwork.IsMasterClient)
        { GameObject.Find("NextWave").SetActive(false); }


    }
}
