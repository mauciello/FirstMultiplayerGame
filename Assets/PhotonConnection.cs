using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonConnection : MonoBehaviourPunCallbacks
{

    [SerializeField] TMP_InputField m_newInputField;
    [SerializeField] TMP_InputField m_newNickName;
    [SerializeField] TMP_Text errorText;
 
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        errorText.text = "";
    }

    public override void OnConnectedToMaster()
    {
        print("Se ha conectado al Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //PhotonNetwork.JoinOrCreateRoom("TestRoom1", newRoomInfo(), null);
    }

    public override void OnJoinedRoom()
    {
        print("Se entró al room");
        //PhotonNetwork.Instantiate("Player", new Vector3(0,0,0), Quaternion.identity);
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("Hubo un error al crear un room: " + message);
        errorText.text = "Error al crear el room: " + message;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        print("Hubo un error al entrar un room: " + message);
        errorText.text = "Error al unirse a ese room: " + message;
    }

    RoomOptions newRoomInfo()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        return roomOptions;
    }

    public void joinRoom()
    {
        print("Se ha entrado al Lobby Abstracto");
        if (m_newNickName.text == null)
        {
            print("Se necesita un nombre");
            return;
        }
        PhotonNetwork.NickName = m_newNickName.text;
        PhotonNetwork.JoinRoom(m_newInputField.text);
    }

    public void createRoom()
    {
        print("Se ha entrado al Lobby Abstracto");
        if (m_newNickName.text == null)
        {
            print("Se necesita un nombre");
            return;
        }
        PhotonNetwork.NickName = m_newNickName.text;
        PhotonNetwork.CreateRoom(m_newInputField.text, newRoomInfo(), null);
    }
}
