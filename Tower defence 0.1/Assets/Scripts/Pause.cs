using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
    public bool isPause;
   public void setpause()
    {
        if (!isPause)
        {
            isPause = true;
            StartScene.GameMenu.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("BlackGame").GetComponent<Image>().enabled = true;
        }
        else
        {
            isPause = false;
            StartScene.GameMenu.SetActive(false);
            Time.timeScale = 1;
            GameObject.Find("BlackGame").GetComponent<Image>().enabled = false;
        }
    }
}
