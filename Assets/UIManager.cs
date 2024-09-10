using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] TextMeshProUGUI m_coinInfo;
    [SerializeField] TextMeshProUGUI m_finalCoinMessage;

    PhotonView m_PV;
    int m_currentScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void actualizarText(int p_newScore)
    {
        m_currentScore += p_newScore;
        m_TextMeshProUGUI.text = "Score: " + p_newScore.ToString();
    }

    private void Start()
    {
        m_TextMeshProUGUI.text = "Score: ";
        m_PV = GetComponent<PhotonView>();
    }

    public void leaveCurrentRoomFromEditor()
    {
        LNM.instance.disconnectFromCurrentRoom();
    }

    public void addNewPoints()
    {
        m_PV.RPC("addNewPointsInUI", RpcTarget.AllBuffered, 5);
    }

    public void getNewInfoGame(string p_playerInfo)
    {
        m_PV.RPC("showNewGameInfo",RpcTarget.All, p_playerInfo);
    }

    public void getCoinsInfo(string p_playerName)
    {
        m_PV.RPC("noMoreCoinsMessage", RpcTarget.All, p_playerName);
    }

    [PunRPC]
    void showNewGameInfo(string p_name)
    {
        m_coinInfo.text = "El jugador:" + p_name + " ganó una moneda";
    }

    [PunRPC]
    void addNewPointsInUI(int p_newScore)
    {
        actualizarText(p_newScore);
    }

    [PunRPC]
    void noMoreCoinsMessage(string p_name)
    {
        if(GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            m_finalCoinMessage.text = "El jugador" + p_name + " agarró la ultima moneda";
        }
         
    }
}
