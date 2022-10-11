using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
        if(CrossPlatformInputManager.GetButtonDown("Hit")  && EsperaDeGolpe)
        {
                                                    //&& PlayerMovement.CheckGroundTf
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

/*if (Input.GetKeyDown(KeyCode.C) && EsperaDeGolpe)
{
    //&& PlayerMovement.CheckGroundTf
    anim.SetTrigger("Ataca");
}*/