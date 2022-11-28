using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] public float HitDamage;
    [SerializeField] public float Vida;
    float VidaActualDelEnemigo;
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
        /*if (collision.gameObject.CompareTag("AtaqueJugador"))
        {
            var direction = Random.Range(-1000, 1000);
            var isRight = collision.gameObject.transform.position.x < ;
            //Fuerza
            var force = Random.Range(3000, 5000);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction, force);

        } */
    }
}