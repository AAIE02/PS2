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
        if(Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("IsAttacking");
            AtaqueCollider.SetActive(true);
        }
        else
        {
            anim.ResetTrigger("IsAttacking");
            AtaqueCollider.SetActive(false);
        }
    }
}
