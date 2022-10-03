using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool Atacando;
    public GameObject target;
    public Animator anim;


    void Start()
    {
        target = GameObject.Find("Player");
    }

    public void ComportamientoDelEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 2 && !Atacando)
        {
            anim.SetBool("EnemyAttack", false);
        }
        else
        {
            anim.SetBool("EnemyAttack", true);
            Atacando = true; 
        }
    }

    public void FinalizarAnimacion()
    {
        anim.SetBool("EnemyAttack", false);
        Atacando = false;
    }
}
