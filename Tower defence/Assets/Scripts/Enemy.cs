using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class Enemy : MonoBehaviourPun
{
    [SerializeField]
    private int HpMob;
    [SerializeField]
    NavMeshAgent agent;
    private Transform targetMarker;
    public int Damage = 1;
    public int GoldForEnemy;
    public float MainAgentSpeed;
    private bool EarthquakeDamage = false;
    private bool SlowNow = false;
    [SerializeField]
    private GameObject Greenbar;
    private int MaxHP;
    private int LastHPMob;



    void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
        agent = gameObject.GetComponent<NavMeshAgent>(); //Присвоение самого себя к agent
        agent.speed *= globalvariable.MobModSpeed; //Увелечение скорости моба
        
        targetMarker = GameObject.FindWithTag("Final").transform; //Назначение выхода
        agent.destination = targetMarker.position;
        switch (agent.name)
        {
            case "Enemy1(Clone)":
                {
                    HpMob = 5;
                    GoldForEnemy = 5;
                }
                break;
            case "Enemy2(Clone)":
                {
                    HpMob = 15;
                    GoldForEnemy = 6;
                }
                break;
            case "Enemy3(Clone)":
                {
                    HpMob = 25;
                    HpMob += 2 * NewEnemy.Wave;
                    GoldForEnemy = 7;
                }
                break;
            case "Enemy4(Clone)":
                {
                    HpMob = 15;
                    GoldForEnemy = 9;
                    HpMob += NewEnemy.Wave;
                }
                break;
            case "Enemy5(Clone)":
                {
                    HpMob = 30;
                    HpMob += NewEnemy.Wave * 2;
                    GoldForEnemy = 11;
                }
                break;
            default:
                { GoldForEnemy = 30; }
                break;
        }
        HpMob += NewEnemy.Wave; //Увелечение здоровья моба
        MaxHP = HpMob;
        LastHPMob = HpMob;

    }

    void Update()
    {
        if ((globalvariable.Earthquake == true) && (EarthquakeDamage == false)) { HpMob -= 1; EarthquakeDamage = true; StartCoroutine(Earthquake()); }
        //Удаление моба и начисление золота при смерти
        if (HpMob <= 0) {
            if (globalvariable.online) { GoldForEnemy /= 2; photonView.RPC("GetMoney", RpcTarget.All, GoldForEnemy); }
            else { Gold.gold += GoldForEnemy; }
            if (globalvariable.online)
            {
                PhotonNetwork.Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, .0f);
            }
           

        }
        if (HpMob != LastHPMob)
        {
            float NowHP = 2f / MaxHP * HpMob;
            Greenbar.transform.localScale = new Vector3(NowHP, 0.051f, 0.11f);
            //Greenbar.transform.position = new Vector3(Greenbar.transform.position.x + NowHP, Greenbar.transform.position.y, Greenbar.transform.position.z);
            LastHPMob = HpMob;
        }

    }
    public void OnTriggerStay(Collider cal)
    {
        if ((globalvariable.FireDamage == true) && (cal.CompareTag("DamageZoneOfFire")))
        {
            Damage *= Random.Range(2, 5);
            HpMob -= Damage;
            Damage = 1;
            globalvariable.FireDamage = false;
        }


    }
    [PunRPC]
    private void GetMoney(int GoldForEnemy)
    {
        Gold.gold += GoldForEnemy;
    }
    public void OnTriggerEnter(Collider cal)
    {
        if (cal.CompareTag("Bullet")) // Попадание снаряда
        {
            if (cal.name != "Bullet_UEarthquake")
            {
                switch (gameObject.name)
                {
                    case "Enemy1U(Clone)":
                        {
                            if ((cal.name == "Bullet_Fire")||(cal.name == "Bullet_UFire")||(cal.name == "Bullet_UFireBall"))
                            {}
                            else
                            {
                                Damage *= Random.Range(2, 5);
                                HpMob -= Damage;
                                Damage = 1;
                            }
                        }
                    break;
                    case "Enemy2U(Clone)":
                        {
                            if ((cal.name == "Bullet_Air") || (cal.name == "Bullet_UTornado") || (cal.name == "Bullet_ULightning"))
                            { }
                            else
                            {
                                Damage *= Random.Range(2, 5);
                                HpMob -= Damage;
                                Damage = 1;
                            }
                        }
                        break;
                    case "Enemy3U(Clone)":
                        {
                            if ((cal.name == "Bullet_Water") || (cal.name == "Bullet_UWater") || (cal.name == "Bullet_UIce"))
                            { }
                            else
                            {
                                Damage *= Random.Range(2, 5);
                                HpMob -= Damage;
                                Damage = 1;
                            }
                        }
                        break;
                    case "Enemy4U(Clone)":
                        {
                            if ((cal.name == "Bullet_Ground") || (cal.name == "Bullet_UStone") || (cal.name == "Bullet_UEarthquake"))
                            { }
                            else
                            {
                                Damage *= Random.Range(2, 5);
                                HpMob -= Damage;
                                Damage = 1;
                            }
                        }
                        break;
                    default:
                        {
                            Damage *= Random.Range(2, 5);
                            HpMob -= Damage;
                            Damage = 1;
                        }
                     break;
                }
                
            }
            switch (cal.name)
             {
                 case "Bullet_UIce":
                     {
                        agent.isStopped = true;
                        StartCoroutine(Freez());
                     }
                     break;
                 case "Bullet_UWater":
                     {
                        
                        if (!SlowNow)
                        {
                            SlowNow = true;
                            MainAgentSpeed = agent.speed;
                            agent.speed *= 0.5f;
                            StartCoroutine(SlowSpeed());
                        }
                     }
                     break;
                case "Bullet_UFire":
                    {
                        StartCoroutine(FireDam());
                    }
                    break;
                case "Bullet_UFireBall":
                    {
                        globalvariable.FireDamage = true;
                    }
                    break;
                case "Bullet_UTornado":
                    {
                        agent.destination = GameObject.FindWithTag("Start").transform.position;
                        StartCoroutine(Tornado());

                    }
                    break;
                case "Bullet_ULightning":
                    {
                        HpMob = 0;
                    }
                    break;
                case "Bullet_UStone":
                    {
                        //Работает
                    }
                    break;
                case "Bullet_UEarthquake":
                    {
                        globalvariable.Earthquake = true;
                        StartCoroutine(Earthquake());
                        
                    }
                    break;

            }
        }
    }
    IEnumerator Freez() //Заморозка
    {
        yield return new WaitForSeconds(3f);
        agent.isStopped = false;
    }
    IEnumerator SlowSpeed() //Замедление скорости
    {
        yield return new WaitForSeconds(7f);
        SlowNow = false;
        agent.speed = MainAgentSpeed;
    }
    IEnumerator FireDam() //Замедление скорости
    {
        for (int i = 0; i < 5; i++)
        {
            HpMob -= 3;
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Tornado() //Замедление скорости
    {
        yield return new WaitForSeconds(5f);
        agent.destination = targetMarker.position;
    }
    IEnumerator Earthquake() //Замедление скорости
    {
        yield return new WaitForSeconds(0.1f);
        globalvariable.Earthquake = false;
        EarthquakeDamage = false;
    }
    private void OnMouseDown()
    {
         if (MenuButtons.DebugMod) { print("Destroy2"); Destroy(gameObject, .0f); }
    }
}
