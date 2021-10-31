using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVL1_4 : MonoBehaviour
{
    public int TaskEnd = 0;
    public GameObject[] Task = new GameObject[11];
    bool isUpTower;
    bool isStartEnd;

   


    void Update()
    {
        switch (TaskEnd)
        {
            case 0:
                {
                    MenuButtons.trialsCounterEnd = 4;
                    if (GameObject.FindGameObjectWithTag("Active_buy")!=null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd+1].SetActive(true);
                        TaskEnd++;
                    }
                }
            break;
            case 1:
                {
                    if ((GameObject.Find("Tower_Air_1(Clone)") != null)|| (GameObject.Find("Tower_Fire_1(Clone)") != null)|| (GameObject.Find("Tower_Ground_1(Clone)") != null)|| (GameObject.Find("Tower_Water_1(Clone)") != null))
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }

                }
                break;
            case 2:
                {
                    if (GameObject.FindWithTag("Active_tower") != null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }

                }
                break;
            case 3:
                {
                    if (isUpTower==true)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        GameObject.Find("NextWave").GetComponent<RawImage>().enabled = true;
                        GameObject.Find("TextNextWave").GetComponent<Text>().enabled = true;
                    }


                }
                break;
            case 4:
                {

                    if (GameObject.FindWithTag("Enemy") != null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        Gold.gold = 150;
                    }
                }
                break;
            case 5:
                {
                    if (isUpTower == true)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }
                }
                break;
            case 6:
                {
                    if (GameObject.FindWithTag("Active_tower") != null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        Gold.gold = 200;
                    }
                }
                break;
            case 7:
                {
                    if (isUpTower == true)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }

                }
                break;
            case 8:
                {
                    if (GameObject.FindWithTag("Active_tower") != null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        Gold.gold = 400;
                    }
                }
                break;
            case 9:
                {
                    
                    if ((GameObject.Find("Tower_AirU_1(Clone)") != null) || (GameObject.Find("Tower_AirU_2(Clone)") != null)  || 
                        (GameObject.Find("Tower_FireU_1(Clone)") != null) || (GameObject.Find("Tower_FireU_2(Clone)") != null) || 
                        (GameObject.Find("Tower_GroundU_1(Clone)") != null) || (GameObject.Find("Tower_GroundU_2(Clone)") != null) ||
                        (GameObject.Find("Tower_WaterU_1(Clone)") != null) || (GameObject.Find("Tower_WaterU_2(Clone)") != null))
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }
                }
                break;
            case 10:
                {
                    if (!isStartEnd)
                    {
                        isStartEnd = true;
                        for (int i = 0; i < 5; i++)
                        {
                            Instantiate(Resources.Load<Transform>("Enemy1"), GameObject.FindWithTag("Start").transform.position, Quaternion.identity);
                        }

                    }
                    if (GameObject.FindWithTag("Enemy") == null)
                    {
                        
                        Task[TaskEnd].SetActive(false);
                        StartScene.GameMenu.SetActive(true);
                        GameObject.Find("BlackGame").GetComponent<Image>().enabled = true;
                        GameObject.Find("Main text").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("trialend");
                        GameObject.Find("Main text").GetComponent<Text>().color = new Color(251, 0, 20);

                        string s = SceneManager.GetActiveScene().name;
                        s = s.Remove(0, 5);
                        int.TryParse(s, out int trialsCounterEnd);
                        trialsCounterEnd++;
                        if (trialsCounterEnd > PlayerPrefs.GetInt("Trial"))
                        {
                            PlayerPrefs.SetInt("Trial", trialsCounterEnd);
                        }
                        Time.timeScale = 0;

                    }
                }
                break;
        }
        isUpTower = false;
        
    }
    public void UpTower()
    {
        isUpTower = true;
    }
    bool IsStart;
    public void Wave()
    {
        if(!IsStart)
        for (int i = 0; i < 4; i++)
        {
            Instantiate(Resources.Load<Transform>("Enemy1"), GameObject.FindWithTag("Start").transform.position, Quaternion.identity);
                IsStart = true;
            
        }
    }
}
