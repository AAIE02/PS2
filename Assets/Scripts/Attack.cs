using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public GameObject AtaqueCollider;
    bool EsperaDeGolpe;

    void Start()
    {
        anim = GetComponent<Animator>();
        EsperaDeGolpe = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && CheckGround.IsGrounded && EsperaDeGolpe)
        {
            anim.SetTrigger("Ataca");
        }
    }

    public void Ataca()
    {
        PlayerMovement.CanMove = false;
        AtaqueCollider.SetActive(true);
        EsperaDeGolpe=false;
    }
    public void DejaDeAtacar()
    {
        PlayerMovement.CanMove = true;
        AtaqueCollider.SetActive(false);
        EsperaDeGolpe = true;
    }
}
