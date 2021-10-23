using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;


public class Tower : MonoBehaviour
{
    public Transform spawpoint;
    public Transform bullet;
    public float speed;
    private float speed1;
    private float speedStone = 1;
    public bool Cooldown = false;  
    public Transform target;
    private bool UnderAttack = false;
   

    protected internal float DamageBullet = 5;
    
    
    void Start()
    { 
        DamageBullet = 1;

        bullet.position = spawpoint.position;
        if (bullet.name == "Bullet_UStone")
        { speedStone = 3; }


    }
    void Update()
    {

         if (target == null) { UnderAttack = false; bullet.position = spawpoint.position;  }
        
        if (UnderAttack)
        {
            if ((globalvariable.online) && (PhotonNetwork.IsMasterClient))
            {
                speed1 = Time.deltaTime * speed * speedStone;
                bullet.position = Vector3.MoveTowards(bullet.position, target.position, speed1);
            }
            else if (!globalvariable.online)
            {
                speed1 = Time.deltaTime * speed * speedStone;
                bullet.position = Vector3.MoveTowards(bullet.position, target.position, speed1);
            }
           
        }
    }
    public void OnTriggerStay(Collider col)
    {
        if (bullet.name == "Bullet_ULightning")
        {
            if (!Cooldown)

            {
                if ((col.CompareTag("Enemy")) && (target == null))
                {
                    target = col.transform; UnderAttack = true; Cooldown = true; StartCoroutine(CD());
                }
            }

        }
        else
        {
            if ((col.CompareTag("Enemy")) && (target == null))
            {
                target = col.transform; UnderAttack = true;
            }
        }


    }
    public void OnTriggerExit(Collider col1)
    {
        if (col1.transform == target)
        {
            UnderAttack = false; target = null; bullet.position = spawpoint.position;
        }
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(5);
        Cooldown = false;
    }
}
