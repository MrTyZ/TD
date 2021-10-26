using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TowerUpU : MonoBehaviour
{
    button_cancel cancel = new button_cancel();
    string nameTower;
    string namePrefab;
    int coast;
    public void Up_Tower_U(string nameTower, string namePrefab, int coast)
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == nameTower)
            {
                if (Gold.gold >= coast)
                {
                    if (globalvariable.online)
                    {
                        PhotonNetwork.Instantiate(namePrefab, GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                        PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("Active_tower"));
                    }
                    else
                    {
                        Instantiate(Resources.Load<Transform>(namePrefab), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                        Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    }

                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= coast;
                }
                else
                {
                    GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                    nomoney();

                }
            }
        }
        cancel.Cancel();
    }
    public void LevelUpWaterU1()
    {
        nameTower = "Water3"; namePrefab = "Tower_WaterU_1"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpWaterU2()
    {
        nameTower = "Water3"; namePrefab = "Tower_WaterU_2"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpFireU1()
    {
        nameTower = "Fire3"; namePrefab = "Tower_FireU_1"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpFireU2()
    {
        nameTower = "Fire3"; namePrefab = "Tower_FireU_2"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpAirU1()
    {
        nameTower = "Air3"; namePrefab = "Tower_AirU_1"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpAirU2()
    {
        nameTower = "Air3"; namePrefab = "Tower_AirU_2"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpGroundU1()
    {
        nameTower = "Ground3"; namePrefab = "Tower_GroundU_1"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }
    public void LevelUpGroundU2()
    {
        nameTower = "Ground3"; namePrefab = "Tower_GroundU_2"; coast = 400; Up_Tower_U(nameTower, namePrefab, coast);
    }

    private void nomoney()
    {
        GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("coastup");
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Main text").GetComponent<Text>().text = "";
    }
}
