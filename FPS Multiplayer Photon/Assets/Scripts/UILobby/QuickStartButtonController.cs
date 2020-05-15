using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartButtonController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;
    [SerializeField]
    private int roomSize;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }
    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();//se puede configurar para buscar salas especificas
        Debug.Log("Partida rapida");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No se ha encontrado partida adecuada");
        CreateRoom();
    }
    void CreateRoom()
    {
        Debug.Log("Creando partida nueva...");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log("Sala nº"+randomRoomNumber+" creada");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Error al crear la sala");
        CreateRoom();
    }
    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}


