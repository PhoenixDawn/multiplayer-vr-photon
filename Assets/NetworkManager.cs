using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public int sceneIndex;
    public int maxPlayer;
}
public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject roomUi;

    [SerializeField]
    private List<DefaultRoom> defaultRooms;

    private void Update()
    {
        
    }
    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server...");
    }

    // After connected, it joins master
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connecting to server...");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    // From master go to lobby (Scene 0)
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined the lobby");
        roomUi.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("New player Joined your room");
    }

    // Pick a room
    public void InitializeRoom(int defaultRoomIndex)
    {
        DefaultRoom roomSettings = defaultRooms[defaultRoomIndex];

        Debug.Log("Connected to server!");
        base.OnConnectedToMaster();

        // Load Scene
        PhotonNetwork.LoadLevel(roomSettings.sceneIndex);

        // Create room
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = (byte)roomSettings.maxPlayer;
        ro.IsVisible = true;
        ro.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, ro, TypedLobby.Default);
    }

    public void Disconnect()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
}
