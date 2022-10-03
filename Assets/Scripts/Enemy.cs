using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HitDamage;
    public float Vida;
    float VidaAcctualDelEemigo;


    void Start()
    {
        VidaAcctualDelEemigo = Vida;
    }


    void Update()
    {
        if(VidaAcctualDelEemigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AtaqueJugador"))
        {
            Vida -= HitDamage;
            Debug.Log(VidaAcctualDelEemigo); 
        }
    }
}
// 1.- Ataque del enemigo y detectar si se hizo parry en el momento correcto
// 2.- Agregar enemigo Tank