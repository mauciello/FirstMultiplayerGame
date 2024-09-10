using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_NicknameUI;

    public float movSpeed = 5f;
   
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    PhotonView m_PV;
    // Start is called before the first frame update
    void Start()
    {
        m_PV = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();

        m_NicknameUI.text = m_PV.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_PV.IsMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            rb.MovePosition(rb.position + movement * movSpeed * Time.deltaTime);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
           UIManager.instance.addNewPoints();
           UIManager.instance.getNewInfoGame(m_PV.Owner.NickName);
           UIManager.instance.getCoinsInfo(m_PV.Owner.NickName);
            //Destroy(collision.gameObject);
        } 
    }
}
