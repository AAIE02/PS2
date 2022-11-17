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
        if(CrossPlatformInputManager.GetButtonDown("Hit") && EsperaDeGolpe)
        {                                   //&& mo.CheckGroundTf, MobileControl.CheckGroundTf
            anim.SetTrigger("Ataca");
        }
    }

    public void Ataca()
    {
        //PlayerMovement.CanMove = false;
        MobileControl.CanMove = false;
        AtaqueCollider.SetActive(true);
        EsperaDeGolpe=false;
    }
    public void DejaDeAtacar()
    {
        //PlayerMovement.CanMove = true;
        MobileControl.CanMove = true;
        AtaqueCollider.SetActive(false);
        EsperaDeGolpe = true;
    }
}
