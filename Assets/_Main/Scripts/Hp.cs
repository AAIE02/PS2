using UnityEngine;
using System;

public class Hp : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maxVida;
    [SerializeField] private HP_Bar barraDeVida;
    [SerializeField] Animator _animator;
    [SerializeField] int ah_death = Animator.StringToHash("IsDeath");
    public event EventHandler PlayerDeath;

    void Start()
    {
        _animator = GetComponent<Animator>();
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
            _animator.SetTrigger(ah_death);
            Destroy(gameObject, 0.8f);
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