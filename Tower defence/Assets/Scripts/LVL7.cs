using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVL7 : MonoBehaviour
{
    public int TaskEnd = 0;
    public GameObject[] Task = new GameObject[2];

    void Update()
    {
        switch (TaskEnd)
        {
            case 0:
                {

                    if (NewEnemy.Wave == 5 )
                    {
                        Task[TaskEnd + 1].SetActive(true);
                        TaskEnd++;
                    }
                }
                break;
            case 1:
                {
                    if ((NewEnemy.Wave == 11) || ((NewEnemy.Wave == 10) && (GameObject.FindGameObjectWithTag("Enemy") == null)))
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
}
