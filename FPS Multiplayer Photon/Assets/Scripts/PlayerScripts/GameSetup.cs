using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;

    public Transform[] spawnPoints;

    private void OnEnable()
    {
        if (GameSetup.GS==null)
        {
            GameSetup.GS = this;
        }
    }

    public Transform getSpawnPoint(Transform[] spawnPoints)
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
    }
    public void DisconnectPlayer()
    {
        StartCoroutine(DisconectAndLoad());
    }
    IEnumerator DisconectAndLoad()
    {
        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
        SceneManager.LoadScene(MultiplayerSetting.multiplayerSetting.menuScene);
    }
}
