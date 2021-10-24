using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpTower : MonoBehaviour
{
    readonly button_cancel cancel = new button_cancel();
    public void LevelUp()
    {
        print("1");
        if (GameObject.FindGameObjectWithTag("Active_tower") != null)
        {
            print(Active_tower.ClassLevel_Tower);
            print("2");
            switch (Active_tower.ClassLevel_Tower)
            {
                
                case "Water1":
                    {
                        if (Gold.gold >= 150)
                        {
                            
                            
                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Water_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity); 
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 150;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Water2":
                    {
                        if (Gold.gold >= 200)
                        {
                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Water_3"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 200;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }

                    break;
                case "Fire1":
                    {
                        if (Gold.gold >= 150)
                        {


                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Fire_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 150;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Fire2":
                    {
                        if (Gold.gold >= 200)
                        {
                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Fire_3"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 200;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Air1":
                    {
                        if (Gold.gold >= 150)
                        {


                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Air_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 150;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Air2":
                    {
                        if (Gold.gold >= 200)
                        {
                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Air_3"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 200;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Ground1":
                    {
                        if (Gold.gold >= 150)
                        {


                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Ground_2"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 150;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;
                case "Ground2":
                    {
                        if (Gold.gold >= 200)
                        {
                            Instantiate(Resources.Load<Transform>("Prefabs/Tower_Ground_3"), GameObject.FindGameObjectWithTag("Active_tower").transform.position, Quaternion.identity);
                            Destroy(GameObject.FindGameObjectWithTag("Active_tower"), .0f);
                            Destroy(GameObject.Find("Sphere(Clone)"), .0f);
                            Gold.gold -= 200;
                        }
                        else
                        {
                            GameObject.Find("Main text").GetComponent<Text>().color = new Color(150, 0, 0);
                            nomoney();
                        }
                    }
                    break;



                default:
                    { }
                    break;
            }




            cancel.Cancel();


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
