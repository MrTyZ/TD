using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SpawnTower : MonoBehaviour
{
   void NoMoney()
    {
        GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
        GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("nomoney");
        StartCoroutine(Pause());
    }
    void BuildError()
    {
        GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
        GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("placeforbuild");
        StartCoroutine(Pause());
    }

    void Spawntower(string NameTower)
    {
        if (GameObject.Find("buy_active(Clone)") != null)
        {
            if (Gold.gold >= 100)
            {
                if (globalvariable.online)
                {
                    PhotonNetwork.Instantiate(NameTower, GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                    Gold.gold -= 100;
                    PhotonNetwork.Destroy(GameObject.Find("buy_active(Clone)"));
                }
                else
                {
                    Instantiate(Resources.Load<Transform>(NameTower), GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                    Destroy(GameObject.Find("buy_active(Clone)"), .0f);
                }
             
            }
            else
            {
                NoMoney();
            }
        }
        else
        {
            BuildError();
        }
    }
    public void Spawn_air()
    {
        string NameTower = "Tower_Air_1";
        Spawntower(NameTower);

    }
    public void Spawn_fire()
    {
        string NameTower = "Tower_Fire_1";
        Spawntower(NameTower);
    }
    public void Spawn_ground()
    {
        string NameTower = "Tower_Ground_1";
        Spawntower(NameTower);
    }
    public void Spawn_water()
    {
        string NameTower = "Tower_water_1";
        Spawntower(NameTower);
    }

    

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Main text").GetComponent<Text>().text = "";
    }
}
