using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVL6 : MonoBehaviour
{
    public int TaskEnd = 0;
    public GameObject[] Task = new GameObject[5];


    void Update()
    {
        switch (TaskEnd)
        {
            case 0:
                {

                    if (GameObject.FindGameObjectWithTag("Active_buy") != null)
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }
                }
                break;
            case 1:
                {
                    if ((GameObject.Find("Tower_Air_1(Clone)") != null) || (GameObject.Find("Tower_Fire_1(Clone)") != null) || (GameObject.Find("Tower_Ground_1(Clone)") != null) || (GameObject.Find("Tower_Water_1(Clone)") != null))
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        Gold.gold = 300;
                    }

                }
                break;
            case 2:
                {
                    if ((GameObject.Find("Tower_Air_1(Clone)") != null) && (GameObject.Find("Tower_Fire_1(Clone)") != null) && (GameObject.Find("Tower_Ground_1(Clone)") != null) && (GameObject.Find("Tower_Water_1(Clone)") != null))
                    {
                        Task[TaskEnd].SetActive(false);
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                        Gold.gold = 750;
                    }

                }
                break;
            case 3:
                {
                    if ((GameObject.Find("Tower_AirU_1(Clone)") != null) || (GameObject.Find("Tower_AirU_2(Clone)") != null) ||
                        (GameObject.Find("Tower_FireU_1(Clone)") != null) || (GameObject.Find("Tower_FireU_2(Clone)") != null) ||
                        (GameObject.Find("Tower_GroundU_1(Clone)") != null) || (GameObject.Find("Tower_GroundU_2(Clone)") != null) ||
                        (GameObject.Find("Tower_WaterU_1(Clone)") != null) || (GameObject.Find("Tower_WaterU_2(Clone)") != null))
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

                    if ((GameObject.FindWithTag("Enemy") == null) && (IsStart))
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
    }
    bool IsStart;
        public void Wave()
        {
            if (!IsStart)
                for (int i = 0; i < 4; i++)
                {
                Instantiate(Resources.Load<Transform>("Enemy1"), GameObject.FindWithTag("Start").transform.position, Quaternion.identity);
                Instantiate(Resources.Load<Transform>("Enemy2"), GameObject.FindWithTag("Start").transform.position, Quaternion.identity);
                IsStart = true;

                }
        }
    
    
   
}
