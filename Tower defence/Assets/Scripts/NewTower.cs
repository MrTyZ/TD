using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NewTower : MonoBehaviour, IPunObservable
{
    button_cancel cancel = new button_cancel();
    public GameObject part1;
    public GameObject part2;
    public Material buy;
    public Material buy_active_host;
    public Material buy_active_client;
    [SerializeField]
    public bool isActive;

    void OnMouseDown()
    {
        if (gameObject.tag == "Active_buy") { cancel.Cancel(); }
        else
        {
            cancel.Cancel();
            gameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);
            if (gameObject.tag == "Buy")
            {
                gameObject.tag = "Active_buy";
                isActive = true;
            }
        }
        
      

    }
    private void Update()
    {
        if (gameObject.tag == "Active_buy")
        {
            part1.GetComponent<MeshRenderer>().material = buy_active_host;
        }
        else if (isActive)
        {
            part1.GetComponent<MeshRenderer>().material = buy_active_client;
        }
        else
        {
            part1.GetComponent<MeshRenderer>().material = buy;
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isActive);
        }
        else
        {
            isActive = (bool) stream.ReceiveNext();
        }
    }
}
