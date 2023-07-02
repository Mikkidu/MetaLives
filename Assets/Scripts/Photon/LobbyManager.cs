using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public delegate void OnNickNameChange(string name);
    public OnNickNameChange OnNickNameChangeEvent;

    private bool _isReadyToJoin = false;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("You connected to server!");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("You joined to lobby");
    }

    public void SaveNickName(string name)
    {
        PhotonNetwork.NickName = name;
        if (OnNickNameChangeEvent != null)
            OnNickNameChangeEvent.Invoke(name);
    }

    public void CreateRoom(string name)
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            if (PhotonNetwork.CurrentRoom.Name == name)
            {
                return;
            }
            PhotonNetwork.LeaveRoom();
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(name, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room succsessfully created!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room!");
    }

    public void JoinRoom(string name)
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            if (PhotonNetwork.CurrentRoom.Name == name)
            {
                EnterRoom();
                return;
            }
            PhotonNetwork.LeaveRoom();
        }
        _isReadyToJoin = true;
        PhotonNetwork.JoinRoom(name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Succsessfully connected to the room!");
        if (_isReadyToJoin)
            EnterRoom();
    }

    private void EnterRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join to the room!");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
