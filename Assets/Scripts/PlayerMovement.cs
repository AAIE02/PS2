 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocidad;
    public float velocidadSalto;
    public static bool CanMove;

    public static  Transform CheckGroundTf;
    Rigidbody2D rigi;

    void Start()
    {
        CanMove = true;
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanMove)
        {
            float h = Input.GetAxisRaw("Horizontal"); 
        Vector2 moveToRigi = new Vector2(h * velocidad, rigi.velocity.y);

        if (Input.GetButtonDown("Jump")) 
        {
            Collider2D col = Physics2D.OverlapCircle(CheckGroundTf.position, 0.1f);
            if (col) 
            {
                moveToRigi.y = velocidadSalto;
            }
        }
        rigi.velocity = moveToRigi;
        FlipControl(h);
        }
    }
    void FlipControl(float h)
    {
        Vector3 escalaActual = transform.localScale;
        if (h != 0)
        {
            escalaActual.x = h > 0f ? 1f : -1f;
        }
        transform.localScale = escalaActual;
    }

    /*Rigidbody2D RB2D;

    public float velocidad;
    public float JumpF;
    public static bool CanMove;


    void Start()
    {
        CanMove = true;
        transform.localPosition = new Vector3(-7f, -2.9f, 0f);
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanMove) { 
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
        }*/
}

   
    
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttackCollider"))
        {
            print("Recibiste damage");
        }
    }*/

//}