using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints; 

    private void Start()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPosition = spawnPoints[randomIndex].position;

        PhotonNetwork.Instantiate("Player", randomPosition, Quaternion.identity);
    }
}

