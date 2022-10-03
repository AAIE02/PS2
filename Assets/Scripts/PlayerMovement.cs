using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D RB2D;

    public float velocidad;
    public float JumpF;


    void Start()
    {
        transform.localPosition = new Vector3(-7f, -2.9f, 0f);
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movimiento
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(velocidad, 0f, 0f) * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-velocidad, 0f, 0f) * Time.deltaTime, Space.World);
        }


        if (Input.GetKey(KeyCode.Space) && CheckGround.IsGrounded)
        {
            RB2D.AddForce(transform.up * JumpF);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttackCollider"))
        {
            print("Recibiste damage");
        }
    }
    
}