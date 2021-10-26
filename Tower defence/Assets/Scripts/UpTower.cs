using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class UpTower : MonoBehaviour
{
    readonly button_cancel cancel = new button_cancel();
    private string nameTower;
    private int coast;
    public void LevelUp()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            print(Active_tower.ClassLevel_Tower);
            switch (Active_tower.ClassLevel_Tower)
            {
                
                case "Water1":
                    {
                        nameTower = "Tower_Water_2"; coast = 150; Up(coast,nameTower);
                    }
                    break;
                case "Water2":
                    {
                        nameTower = "Tower_Water_3"; coast = 200; Up(coast, nameTower);
                    }
                    break;
                case "Fire1":
                    {
                        nameTower = "Tower_Fire_2"; coast = 150; Up(coast, nameTower);
                    }
                    break;
                case "Fire2":
                    {
                        nameTower = "Tower_Fire_3"; coast = 200; Up(coast, nameTower);
                    }
                    break;
                case "Air1":
                    {
                        nameTower = "Tower_Air_2"; coast = 150; Up(coast, nameTower);
                    }
                    break;
                case "Air2":
                    {
                        nameTower = "Tower_Air_3"; coast = 200; Up(coast, nameTower);
                    }
                    break;
                case "Ground1":
                    {
                        nameTower = "Tower_Ground_2"; coast = 150; Up(coast, nameTower);
                    }
                    break;
                case "Ground2":
                    {
                        nameTower = "Tower_Ground_3"; coast = 200; Up(coast, nameTower);
                    }
                    break;

                default:
                    { }
                    break;
            }
            
            cancel.Cancel();
        }
        
    }
    private void Up(int cost, string nameTower)
    {

        if (Gold.gold >= cost)
        {

            if (globalvariable.online)
            {
                PhotonNetwork.Instantiate(nameTower, GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("Active_tower"));
                Destroy(GameObject.Find("Sphere(Clone)"), .0f);
            }
            else
            {
                Instantiate(Resources.Load<Transform>(nameTower), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                Destroy(GameObject.Find("Sphere(Clone)"), .0f);
            }            
            Gold.gold -= cost;
        }
        else
        {
            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
            nomoney();
        }

    }
    private void nomoney()
    {
        GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("nomoney");
        StartCoroutine(Pause());
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Main text").GetComponent<Text>().text = "";
    }

}
