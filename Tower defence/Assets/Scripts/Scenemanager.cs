using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class Scenemanager : MonoBehaviour
{
   public void LoadInfinity()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main1");
       
    }
  
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");

    }
    public void trial(string s)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Trial"+s);
    }
    public void Leave()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

}
