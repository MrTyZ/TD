using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;


public class Tower : MonoBehaviour
{
    public Transform spawpoint;
    public GameObject bullet;
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

        bullet.transform.position = spawpoint.position;
        if (bullet.name == "Bullet_UStone")
        { speedStone = 3; }
        if (globalvariable.online)
        {
            if (!PhotonNetwork.IsMasterClient) { bullet.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.MasterClient); }
        }
        

    }
    void FixedUpdate()
    {

         if (target == null) { UnderAttack = false; bullet.transform.position = spawpoint.position;  }
        
        if (UnderAttack)
        {
            if ((globalvariable.online) && (PhotonNetwork.IsMasterClient))
            {
                speed1 = Time.fixedDeltaTime * speed * speedStone;
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, target.position, speed1);
            }
            else if (!globalvariable.online)
            {
                speed1 =  Time.fixedDeltaTime * speed * speedStone;
                bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, target.position, speed1);
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
            UnderAttack = false; target = null; bullet.transform.position = spawpoint.position;
        }
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(5);
        Cooldown = false;
    }
}
