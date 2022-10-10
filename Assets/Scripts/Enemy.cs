using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HitDamage;
    public float Vida;
    float VidaActualDelEnemigo;


    public GameObject PlayerHit;
    float force = 150f;


    void Start()
    {
        VidaActualDelEnemigo = Vida;
    }


    void Update()
    {
        if(VidaActualDelEnemigo <= 0)
        {
            Destroy(gameObject,2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AtaqueJugador"))
        {
            VidaActualDelEnemigo -= HitDamage;
            Debug.Log(VidaActualDelEnemigo); 
        }

        if (collision.gameObject.CompareTag("AtaqueJugador"))
        {
            Vector2 PushDirection = (transform.forward - PlayerHit.transform.position);
            gameObject.GetComponent<Rigidbody2D>().AddForce(PushDirection * force);

        }
    }
}
//XD

// 1.- Nivel y cuando se golpea a un enemigo salga volando y muera despues de 2 segundos
// 2.- Hacer un spawner en el que aparezcan muchos enemigos, deben salir volando en distintas direcciones y velocidades
// 3.- Hacer controles para movil
// 4.- Compilar