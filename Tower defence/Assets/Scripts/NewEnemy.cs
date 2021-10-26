using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NewEnemy : MonoBehaviourPun
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy1U;
    public GameObject enemy2U;
    public GameObject enemy3U;
    public GameObject enemy4U;
    public GameObject enemy5U;
    int mob1 = 5, mob2 = 5, mob3 = 3, mob4 = 5, mob5 = 5, mobr = 1;
    public static int Wave = 1;
    public static bool a = false;
    float wavef;
    public static int wave = 1;
    float deltaWave = 21;
    public static float timerWave = 0;
    public static int nextwave;
    public static bool FirstWave = false;

    private void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
        Wave = 1;
        wave = 1;
        nextwave = 20;
        FirstWave = false;
    }
    void SpawnEnemy(GameObject enemy, int count)
    {
        if (globalvariable.online)
        {
            for (int i = 0; i < mob1; i++)
            {
                PhotonNetwork.Instantiate(enemy.name, transform.position, Quaternion.identity);

            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);

            }
        }
    }
    void Update()
    {
        GameObject.Find("CountWaveText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("wave") + Wave.ToString();
        GameObject.Find("NextWaveText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("wavetimer") + nextwave.ToString();

            if (NextWave.start)
            {
                if (!FirstWave)
                {
                   SpawnEnemy(enemy1,5);
                   FirstWave = true;
                }
           
            if ((wave == 20) && (a == false))
            {
                a = true; Wave++;
                if (globalvariable.online) { photonView.RPC("GetMoney", RpcTarget.All, null); }
                else { Gold.gold += 30; }
                
                if (Wave % 5 == 0) { globalvariable.MobModSpeed += 0.3F; mobr = Random.Range(1, 5); }

                if (Wave < 10)//Волны до 10 волны
                {
                    SpawnEnemy(enemy1, mob1);
                    mob1 += Random.Range(1, 3);
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy2, mobr);

                    }
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy1, mobr);
                    }
                }
                else if (Wave == 10) { SpawnEnemy(enemy1U, 1); }
                else if (Wave < 20) // Волны с 11 по 20
                {
                    mob1 = Random.Range(0, 6);
                    SpawnEnemy(enemy1, mob1);
                    SpawnEnemy(enemy2, mob2);
                    mob2 += Random.Range(1, 4);
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy3, mobr);
                    }
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy4, mobr);
                    }
                }
                else if (Wave == 20) { SpawnEnemy(enemy2U, 1); }
                else if (Wave < 30) // волны с 20 по 30
                {
                    mob1 = Random.Range(0, 8);
                    mob2 = Random.Range(3, 7);
                    SpawnEnemy(enemy1, mob1);
                    SpawnEnemy(enemy2, mob2);
                    SpawnEnemy(enemy3, mob3);
                    mob3 += Random.Range(0, 1);
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy4, mobr);
                    }
                    if (Random.Range(0, 1) == 1)
                    {
                        SpawnEnemy(enemy5, mobr);
                    }
                }
                else if (Wave == 30) { SpawnEnemy(enemy3U, 1); }
                else if (Wave < 40) // волны с 30 по 40
                {
                    mob1 = Random.Range(4, 8);
                    mob2 = Random.Range(0, 5);
                    mob3 = Random.Range(1, 2);
                    SpawnEnemy(enemy1, mob1);
                    SpawnEnemy(enemy2, mob2);
                    SpawnEnemy(enemy3, mob3);
                    SpawnEnemy(enemy4, mob4);
                    mob4 += Random.Range(5, 15);
                }
                else if (Wave == 40) { SpawnEnemy(enemy4U, 1); }
                else //Волны после 40
                {
                    mob1 = Random.Range(0, 3);
                    mob2 = Random.Range(2, 7);
                    mob3 = Random.Range(1, 5);
                    mob4 = Random.Range(3, 5);
                    SpawnEnemy(enemy1, mob1);
                    SpawnEnemy(enemy2, mob2);
                    SpawnEnemy(enemy3, mob3);
                    SpawnEnemy(enemy4, mob4);
                    SpawnEnemy(enemy5, mob5);
                    mob5 += Random.Range(5, 20);
                }
                
            }
            timerWave += Time.deltaTime;
            wavef = timerWave % deltaWave;
            wave = (int)wavef;
            nextwave = 20 - wave;
            if (wave == 1) { a = false; }


        }

    }
    [PunRPC]
    private void GetMoney()
    {
        Gold.gold += 15;
    }
}
