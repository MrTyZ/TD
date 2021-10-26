using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class button_cancel : MonoBehaviour
{    public void Cancel()
    {
        //Очистка всех кнопок и информации и башне
        GameObject.Find("UpTower").GetComponent<RawImage>().enabled = false; 
        GameObject.Find("Water_U1").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Water_U2").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Fire_U1").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Fire_U2").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Air_U1").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Air_U2").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Ground_U1").GetComponent<RawImage>().enabled = false;
        GameObject.Find("Ground_U2").GetComponent<RawImage>().enabled = false;





        
        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
        GameObject.Find("DescriptionTowerBackground").GetComponent<RawImage>().enabled = false;

        GameObject.Find("NameTower").GetComponent<Text>().text = "";
        GameObject.Find("NameTowerBackground").GetComponent<RawImage>().enabled = false;
        
        GameObject.Find("LevelTower").GetComponent<Text>().text = "";
        GameObject.Find("LevelTowerBackground").GetComponent<RawImage>().enabled = false;

        GameObject.Find("CoastUPTower").GetComponent<Text>().text = "";
        GameObject.Find("CoastUPTowerBackground").GetComponent<RawImage>().enabled = false;

        GameObject.Find("PhotoTower").GetComponent<RawImage>().enabled = false;
        if (GameObject.FindGameObjectWithTag("Active_tower") != null) //Очистка, если была активная вышка
        {
            GameObject.FindGameObjectWithTag("Active_tower").tag = "Untagged"; 
            Destroy(GameObject.Find("Sphere(Clone)"), .0f); //Удаление подстветки
            

        }
        if (GameObject.FindGameObjectWithTag("Active_buy") != null) 
        {
            GameObject.FindGameObjectWithTag("Active_buy").GetComponent<NewTower>().isActive = false;
            GameObject.FindGameObjectWithTag("Active_buy").tag = "Buy";
        }
        
    }
    public void OnMouseDown()
    {
        Cancel();
    }
}
