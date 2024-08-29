using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
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
    }

    //[PunRPC]
    //void addPointsInUI(int p_newScore)
    //{
    //    UIManager.instance.actualizarText(p_newScore);
    //}

}
