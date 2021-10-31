using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public GameObject hostbtn;
    public GameObject joinbtn;
    public GameObject hostform;
    public GameObject RoomName;
    public GameObject RoomNameEnter;
    public GameObject StartMaster;
    public GameObject Left;
    public GameObject Right;
    public bool connected;

    MenuButtons menubtn = new MenuButtons();
    
    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        PhotonNetwork.NickName = "Player" + Random.Range(1, 9999);
        print(PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "0.7";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();


        
    }
    public override void OnConnected()
    {
        base.OnConnected();
    }
    private void Update()
    {
        if ((PhotonNetwork.IsConnected)&&(!PhotonNetwork.InRoom))
        {
            hostbtn.SetActive(true);
            joinbtn.SetActive(true);
        }
        else
        {
            hostbtn.SetActive(false);
            joinbtn.SetActive(false);
        }
        if (PhotonNetwork.InRoom)
        {
            if ((PhotonNetwork.CurrentRoom.PlayerCount == 2) && (PhotonNetwork.IsMasterClient))
            {
                StartMaster.SetActive(true);
                Left.SetActive(true);
                Right.SetActive(true);
            }
            else
            {
                StartMaster.SetActive(false);
                Left.SetActive(false);
                Right.SetActive(false);
            }
        }
    }
    public void CreateRoom()
    {
        hostbtn.SetActive(false);
        joinbtn.SetActive(false);
        hostform.SetActive(true);
        RoomNameEnter.SetActive(false);
        menubtn.swapmapinfinity();
        PhotonNetwork.CreateRoom(RoomName.GetComponent<Text>().text, new RoomOptions { MaxPlayers = 2 });
    }
    public void CreateFinalRoom()
    {
            PhotonNetwork.LoadLevel("MainMultiplayer");
    }
   
    public void JoinRoom()
    {
            PhotonNetwork.JoinRoom(RoomName.GetComponent<Text>().text);
    }
    public override void OnJoinedRoom()
    {
        globalvariable.online = true;
        GameObject.Find("Log").GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName+" connected.\n";
        GameObject.Find("Log").GetComponent<Text>().text = globalvariable.online + "\n";

    }
    public override void OnLeftRoom()
    {
        globalvariable.online = false;
    }
    public void back()
    {
        hostbtn.SetActive(true);
        joinbtn.SetActive(true);
        hostform.SetActive(false);
        RoomNameEnter.SetActive(true);
    }
    public void Leave()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("MultiplayerText").GetComponent<Text>().text = "";
    }
    IEnumerator Online()
    {
        yield return new WaitForSeconds(1f);
        globalvariable.online = true;
    }
}
