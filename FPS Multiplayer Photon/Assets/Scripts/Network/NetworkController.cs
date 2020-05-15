using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using System;

public class NetworkController : MonoBehaviourPunCallbacks
{

    public static NetworkController lobby;
    [SerializeField]
    TextMeshProUGUI infoserver;


    private void Awake()
    {
        lobby = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        infoserver.text="region: "+PhotonNetwork.CloudRegion + " server";
        infoserver.text = infoserver.text.ToUpper();
        Debug.Log("Estamos conectados al servidor de "+PhotonNetwork.CloudRegion);
        //base.OnConnectedToMaster();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
