using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

public class NewTower : MonoBehaviour
{
    button_cancel cancel = new button_cancel();

    void OnMouseDown()
    {

            cancel.Cancel();
        if (gameObject.name != "buy_active(Clone)")
        {
            if (!globalvariable.online)
            {

                Instantiate(Resources.Load<Transform>("buy_active"), transform.position, Quaternion.identity);
                Destroy(gameObject, .0f);
            }
            else
            {
                PhotonNetwork.Instantiate("buy_active", transform.position, Quaternion.identity);
                GameObject.Find("log").GetComponent<Text>().text += "Del " + gameObject.name + "\n";
                if (gameObject.GetComponent<PhotonView>().IsMine)
                {
                    PhotonNetwork.Destroy(gameObject);
                }
            }
           
  
        }
        
    }




}
