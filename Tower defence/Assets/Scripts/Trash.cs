using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Trash : MonoBehaviour
{
    button_cancel cancel = new button_cancel();
    private int goldsel;
    public void del()
    {
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            switch (Active_tower.ClassLevel_Tower)

            {

                case "Water1":
                    {
                        goldsel = 50;
                    }
                    break;
                case "Water2":
                    {
                        goldsel = 100;
                    }
                    break;
                case "Water3":
                    {
                        goldsel = 225;
                    }
                    break;
                case "Fire1":
                    {
                        goldsel = 50;
                    }
                    break;
                case "Fire2":
                    {
                        goldsel = 100;
                    }
                    break;
                case "Fire3":
                    {
                        goldsel = 225;

                    }
                    break;
                case "Air1":
                    {
                        goldsel = 50;
                    }
                    break;
                case "Air2":
                    {
                        goldsel = 100;
                    }
                    break;
                case "Air3":
                    {
                        goldsel = 225;
                    }
                    break;
                case "Ground1":
                    {
                        goldsel = 50;
                    }
                    break;
                case "Ground2":
                    {
                        goldsel = 100;
                    }
                    break;
                case "Ground3":
                    {
                        goldsel = 225;
                    }
                    break;
                case "WaterU1":
                    {
                        goldsel = 425;
                    }
                    break;
                case "WaterU2":
                    {
                        goldsel = 425;
                    }
                    break;
                case "FireU1":
                    {
                        goldsel = 425;
                    }
                    break;
                case "FireU2":
                    {
                        goldsel = 425;
                    }
                    break;
                case "AirU1":
                    {
                        goldsel = 425;
                    }
                    break;
                case "AirU2":
                    {
                        goldsel = 425;
                    }
                    break;
                case "GroundU1":
                    {
                        goldsel = 425;
                    }
                    break;
                case "GroundU2":
                    {
                        goldsel = 425;
                    }
                    break;

                default:
                    { }
                    break;
            }
            if (globalvariable.online) {
            PhotonNetwork.Instantiate("Buy", GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
            PhotonNetwork.Destroy(GameObject.FindGameObjectWithTag("Active_tower"));
            }
            else {
                Instantiate(Resources.Load<Transform>("Buy"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
            }
            Gold.gold += goldsel;
            cancel.Cancel();
            Destroy(GameObject.Find("Sphere(Clone)"), .0f);


        }
        
    }
    
}
