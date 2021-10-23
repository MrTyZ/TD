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
    public void Spawn_air()
    {
        if (GameObject.Find("buy_active(Clone)") != null)
        {
            if (Gold.gold >= 100)
            {
                PhotonNetwork.Instantiate("Tower_Air_1", GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                //Instantiate(Resources.Load<Transform>("Prefabs/Tower_Air_1"), GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                Gold.gold -= 100;
                PhotonNetwork.Destroy(GameObject.Find("buy_active(Clone)"));
                //Destroy(GameObject.Find("buy_active(Clone)"), .0f);
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
    public void Spawn_fire()
    {
        if (GameObject.Find("buy_active(Clone)") != null)
        {
            if (Gold.gold >= 100)
            {
                Instantiate(Resources.Load<Transform>("Prefabs/Tower_Fire_1"), GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                Gold.gold -= 100;
                Destroy(GameObject.Find("buy_active(Clone)"), .0f);
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
    public void Spawn_ground()
    {
        if (GameObject.Find("buy_active(Clone)") != null)
        {
            if (Gold.gold >= 100)
            {
                Instantiate(Resources.Load<Transform>("Prefabs/Tower_Ground_1"), GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                Gold.gold -= 100;
                Destroy(GameObject.Find("buy_active(Clone)"), .0f);
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
    public void Spawn_water()
    {
        if (GameObject.Find("buy_active(Clone)") != null)
        {
            if (Gold.gold >= 100)
            {
                Instantiate(Resources.Load<Transform>("Prefabs/Tower_water_1"), GameObject.Find("buy_active(Clone)").transform.position, Quaternion.identity);
                Gold.gold -= 100;
                Destroy(GameObject.Find("buy_active(Clone)"), .0f);
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

    

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Main text").GetComponent<Text>().text = "";
    }
}
