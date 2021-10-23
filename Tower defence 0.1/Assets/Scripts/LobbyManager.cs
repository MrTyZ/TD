﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject log;
    public GameObject hostbtn;
    public GameObject joinbtn;
    public GameObject hostform;
    public GameObject RoomName;
    public GameObject RoomNameEnter;
    public bool connected;

    MenuButtons menubtn = new MenuButtons();
    
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1, 9999);
        log.GetComponent<Text>().text += PhotonNetwork.NickName+"\n";
        print(PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "0.7";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        
    }
    public void CreateRoom()
    {
        hostbtn.SetActive(false);
        joinbtn.SetActive(false);
        hostform.SetActive(true);
        RoomNameEnter.SetActive(false);
        menubtn.swapmapinfinity();
    }
    public void CreateFinalRoom()
    {
        globalvariable.online = true;
        PhotonNetwork.CreateRoom(RoomName.GetComponent<Text>().text, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }
    public void JoinRoom()
    {
        globalvariable.online = true;
        if (RoomName.GetComponent<Text>().text != null)
        {
            PhotonNetwork.JoinRoom(RoomName.GetComponent<Text>().text);
        }
        else {GameObject.Find("MultiplayerText").GetComponent<Text>().text = localisationSystem.GetLocalisedValue("ConnError"); StartCoroutine(Pause()); }
    }
    public override void OnJoinedRoom()
    {
        log.GetComponent<Text>().text += PhotonNetwork.NickName + "join";
        PhotonNetwork.LoadLevel("MainMultiplayer");
       
    }
    public void back()
    {
        hostbtn.SetActive(true);
        joinbtn.SetActive(true);
        hostform.SetActive(false);
        RoomNameEnter.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to master");
        log.GetComponent<Text>().text += "Connected to master\n";
    }

   
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(MenuButtons.SelectArray);
        }
        else 
        {
            MenuButtons.SelectArray = (int)stream.ReceiveNext();
        }
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("MultiplayerText").GetComponent<Text>().text = "";
    }
}
