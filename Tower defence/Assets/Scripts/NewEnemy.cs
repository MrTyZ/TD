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
    [SerializeField]
    private int mob1 = 5, mob2 = 3, mob3 = 2, mob4 = 2, mob5 = 2, mobr = 1;
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
    IEnumerator SpawnEnemy(GameObject enemy, int count)
    {
        if (globalvariable.online)
        {
            for (int i = 0; i < count; i++)
            {
                PhotonNetwork.Instantiate(enemy.name, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
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
                StartCoroutine(SpawnEnemy(enemy1, 5));
                FirstWave = true;
                }
           
            if ((wave == 20) && (a == false))
            {
                a = true; Wave++;
                if (globalvariable.online) { photonView.RPC("GetMoney", RpcTarget.All, null); }
                else { Gold.gold += 80; }
                
                if (Wave % 5 == 0) { globalvariable.MobModSpeed += 0.25F; mobr = Random.Range(1, 3); }

                if ((Wave < 10) && (Wave != 5))//Волны до 10 волны
                {
                    StartCoroutine(SpawnEnemy(enemy1, mob1));
                    mob1 += Random.Range(1, 3);
                    if (Random.Range(0, 2) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy2, mobr));

                    }
                    if (Random.Range(0, 2) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy1, mobr));
                    }
                }
                else if (Wave == 5) { StartCoroutine(SpawnEnemy(enemy1U, 1)); }
                else if (Wave == 10) { StartCoroutine(SpawnEnemy(enemy1U, 1)); }
                else if ((Wave < 20) && (Wave != 15)) // Волны с 11 по 20
                {
                    mob1 = Random.Range(0, 5);
                    StartCoroutine(SpawnEnemy(enemy1, mob1));
                    StartCoroutine(SpawnEnemy(enemy2, mob2));
                    mob2 += Random.Range(0, 3);
                    if (Random.Range(0, 4) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy3, mobr));
                    }
                    if (Random.Range(0, 4) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy4, mobr));
                    }
                }
                else if (Wave == 15) { StartCoroutine(SpawnEnemy(enemy2U, 1)); }
                else if (Wave == 20) { StartCoroutine(SpawnEnemy(enemy2U, 1)); }
                else if ((Wave < 30) && (Wave != 25)) // волны с 20 по 30
                {
                    mob1 = Random.Range(0, 4);
                    mob2 = Random.Range(0, 3);
                    StartCoroutine(SpawnEnemy(enemy1, mob1));
                    StartCoroutine(SpawnEnemy(enemy2, mob2));
                    StartCoroutine(SpawnEnemy(enemy3, mob3));
                    mob3 += Random.Range(0, 2);
                    if (Random.Range(0, 4) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy4, mobr));
                    }
                    if (Random.Range(0, 4) == 1)
                    {
                        StartCoroutine(SpawnEnemy(enemy5, mobr));
                    }
                }
                else if (Wave == 25) { StartCoroutine(SpawnEnemy(enemy3U, 1)); }
                else if (Wave == 30) { StartCoroutine(SpawnEnemy(enemy3U, 1)); }
                else if ((Wave < 40) && (Wave != 35)) // волны с 30 по 40
                {
                    mob1 = Random.Range(2, 6);
                    mob2 = Random.Range(0, 3);
                    mob3 = Random.Range(1, 3);
                    StartCoroutine(SpawnEnemy(enemy1, mob1));
                    StartCoroutine(SpawnEnemy(enemy2, mob2));
                    StartCoroutine(SpawnEnemy(enemy3, mob3));
                    StartCoroutine(SpawnEnemy(enemy4, mob4));
                    mob4 += Random.Range(2, 5);
                }
                else if (Wave == 35) { StartCoroutine(SpawnEnemy(enemy4U, 1)); }
                else if (Wave == 40) { StartCoroutine(SpawnEnemy(enemy4U, 1)); }
                else if (Wave % 5 == 0) { StartCoroutine(SpawnEnemy(enemy5U, 1)); }
                else //Волны после 40
                {
                    mob1 = Random.Range(0, 3);
                    mob2 = Random.Range(2, 7);
                    mob3 = Random.Range(1, 5);
                    mob4 = Random.Range(3, 5);
                    StartCoroutine(SpawnEnemy(enemy1, mob1));
                    StartCoroutine(SpawnEnemy(enemy2, mob2));
                    StartCoroutine(SpawnEnemy(enemy3, mob3));
                    StartCoroutine(SpawnEnemy(enemy4, mob4));
                    StartCoroutine(SpawnEnemy(enemy5, mob5));
                    mob5 += Random.Range(3, 10);
                }
                
            }
            timerWave += Time.deltaTime;
            wavef = timerWave % deltaWave;
            wave = (int)wavef;
            if ((globalvariable.online)&&(PhotonNetwork.IsMasterClient)) { photonView.RPC("time", RpcTarget.All, wave, Wave); }
            else
            {
                
                nextwave = 20 - wave;
            }
            
            if (wave == 1) { a = false; }


        }

    }
    [PunRPC]
    private void GetMoney()
    {
        Gold.gold += 40;
    }
    [PunRPC]
    private void time(int wave, int Wave1)
    {
        Wave = Wave1;
        nextwave = 20 - wave;
    }
}
