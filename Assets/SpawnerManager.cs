using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform m_spawner1;

    private void Start()
    {
        PhotonNetwork.Instantiate("Player", m_spawner1.position, Quaternion.identity);
    }
}

