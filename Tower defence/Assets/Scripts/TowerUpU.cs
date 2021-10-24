using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpU : MonoBehaviour
{
    button_cancel cancel = new button_cancel();

    public void LevelUpWaterU1()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Water3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_WaterU_1"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpWaterU2()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Water3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_WaterU_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpFireU1()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Fire3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_FireU_1"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpFireU2()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Fire3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_FireU_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpAirU1()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Air3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_AirU_1"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpAirU2()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Air3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_AirU_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpGroundU1()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Ground3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_GroundU_1"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
    public void LevelUpGroundU2()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            if (Active_tower.ClassLevel_Tower == "Ground3")
            {
                if (Gold.gold >= 400)
                {
                    Instantiate(Resources.Load<Transform>("Prefabs/Tower_GroundU_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                    Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                    Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                    Gold.gold -= 400;
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
