using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Transform spawnpoint;
    public void OnTriggerEnter(Collider cal)
    {
        if (cal.tag == "Enemy")
        {
            if (gameObject.name == "Bullet_UFireBall") { StartCoroutine(CDFire()); }
            else
            { transform.position = spawnpoint.position; } //Возврашение патрона при попадние
        }
    }
    IEnumerator CDFire()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = spawnpoint.position;
    }

}
