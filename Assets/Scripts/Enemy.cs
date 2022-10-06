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
// 1.- Nivel y cuando se golpea a un enemigo salga volando y muera despues de 2 segundos
// 2.- Hacer un spawner en el que aparezcan muchos enemigos, deben salir volando en distintas direcciones y velocidades
// 3.- Hacer controles para movil
// 4.- Compilar