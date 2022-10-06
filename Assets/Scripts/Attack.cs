using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject AtaqueCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && CheckGround.IsGrounded)
        {
            anim.SetTrigger("Ataca");
        }
    }

    public void Ataca()
    {
        PlayerMovement.CanMove = false;
        AtaqueCollider.SetActive(true);
    }
    public void DejaDeAtacar()
    {
        PlayerMovement.CanMove = true;
        AtaqueCollider.SetActive(false);
    }
}
