using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;

public class Hp : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maxVida;
    [SerializeField] private HP_Bar barraDeVida;
    public event EventHandler PlayerDeath;
    Animator animator;
    int ah_death = Animator.StringToHash("IsDeath");


    void Start()
    {
        animator = GetComponent<Animator>();
        vida = maxVida;
        barraDeVida.BarraDeVida(vida);
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        barraDeVida.ChangeCurrentHP(vida);
        if(vida <= 0)
        {
            animator.SetTrigger(ah_death);
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 0.9f);
        }
    }

    public void Curar(float curacion)
    {
        if((vida + curacion) > maxVida)
        {
            vida = maxVida;
        }
    }
}
