using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Active_tower : MonoBehaviour
{ 
    public static string Level_Tower;
    public static string Class_Tower;
    public static string ClassLevel_Tower;
    private int UpCoats = 0;
    button_cancel cancel = new button_cancel();
    [SerializeField]
    private bool isActive;
    void OnMouseDown()
    {
        if (gameObject.tag == "Active_tower") { cancel.Cancel(); }
        else
        {
            cancel.Cancel();

            gameObject.tag = "Active_tower";
            isActive = true;
            gameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

            Instantiate(Resources.Load<Transform>("Prefabs/Sphere"), transform.position, Quaternion.identity); // Подсветка башни


            Level_Tower = gameObject.name;
            Class_Tower = gameObject.name;
            Level_Tower = Level_Tower.Remove(Level_Tower.Length - 7, 7); //Отделение цифры уровня башни
            Level_Tower = Level_Tower.Remove(0, Level_Tower.Length - 1);
            Class_Tower = Class_Tower.Remove(Class_Tower.Length - 9, 9); //Отделение класса башни
            Class_Tower = Class_Tower.Remove(0, 6);
            ClassLevel_Tower = Class_Tower + Level_Tower;

            switch (ClassLevel_Tower)
            {

                case "Water1":
                    {
                        UpCoats = 150;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl1");
                    }
                    break;
                case "Water2":
                    {
                        UpCoats = 200;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl2");
                    }
                    break;
                case "Water3":
                    {
                        UpCoats = 400;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl3water");
                    }
                    break;
                case "Fire1":
                    {
                        UpCoats = 150;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl1");
                    }
                    break;
                case "Fire2":
                    {
                        UpCoats = 200;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl2");
                    }
                    break;
                case "Fire3":
                    {
                        UpCoats = 400;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl3fire");

                    }
                    break;
                case "Air1":
                    {
                        UpCoats = 150;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl1");
                    }
                    break;
                case "Air2":
                    {
                        UpCoats = 200;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl2");
                    }
                    break;
                case "Air3":
                    {
                        UpCoats = 400;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl3air");
                    }
                    break;
                case "Ground1":
                    {
                        UpCoats = 150;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl1");
                    }
                    break;
                case "Ground2":
                    {
                        UpCoats = 200;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl2");
                    }
                    break;
                case "Ground3":
                    {
                        UpCoats = 400;
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("lvl3ground");
                    }
                    break;
                case "WaterU1":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "WaterU2":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "FireU1":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "FireU2":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "AirU1":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "AirU2":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "GroundU1":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;
                case "GroundU2":
                    {
                        GameObject.Find("DescriptionTower").GetComponent<Text>().text = "";
                    }
                    break;

                default:
                    { }
                    break;
            }


            GameObject.Find("NameTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue(Class_Tower);// Вывод информации о башне на экран
            GameObject.Find("NameTowerBackground").GetComponent<RawImage>().enabled = true;

            GameObject.Find("LevelTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("leveltower") + Level_Tower;
            GameObject.Find("LevelTowerBackground").GetComponent<RawImage>().enabled = true;

            GameObject.Find("CoastUPTower").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("coastup") + UpCoats;
            GameObject.Find("CoastUPTowerBackground").GetComponent<RawImage>().enabled = true;

            GameObject.Find("PhotoTower").GetComponent<RawImage>().texture = Resources.Load<Texture>("Photo/" + ClassLevel_Tower);
            GameObject.Find("PhotoTower").GetComponent<RawImage>().enabled = true;

            GameObject.Find("DescriptionTowerBackground").GetComponent<RawImage>().enabled = true;


            if (Level_Tower == "3") //Включение кнопок ульт
            {

                switch (ClassLevel_Tower)
                {
                    case "Air3":
                        {
                            GameObject.Find("Air_U1").GetComponent<RawImage>().enabled = enabled;
                            GameObject.Find("Air_U2").GetComponent<RawImage>().enabled = enabled;
                        }
                        break;
                    case "Ground3":
                        {
                            GameObject.Find("Ground_U1").GetComponent<RawImage>().enabled = enabled;
                            GameObject.Find("Ground_U2").GetComponent<RawImage>().enabled = enabled;
                        }
                        break;
                    case "Water3":
                        {
                            GameObject.Find("Water_U1").GetComponent<RawImage>().enabled = enabled;
                            GameObject.Find("Water_U2").GetComponent<RawImage>().enabled = enabled;
                        }
                        break;
                    case "Fire3":
                        {
                            GameObject.Find("Fire_U1").GetComponent<RawImage>().enabled = enabled;
                            GameObject.Find("Fire_U2").GetComponent<RawImage>().enabled = enabled;
                        }
                        break;
                    default:
                        { }
                        break;
                }
            }
            else //Включение кнопки прокачки
                if (Class_Tower.Remove(0, Class_Tower.Length - 1) != "U")
            {
                GameObject.Find("UpTower").GetComponent<RawImage>().enabled = enabled;
            }

        }

    }

   
}
