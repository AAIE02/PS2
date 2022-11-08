using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class Hp : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maxVida;
    [SerializeField] private HP_Bar barraDeVida;
    public event EventHandler PlayerDeath;

    void Start()
    {
        vida = maxVida;
        barraDeVida.BarraDeVida(vida);
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        barraDeVida.ChangeCurrentHP(vida);
        if(vida <= 0)
        {
            PlayerDeath?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
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
