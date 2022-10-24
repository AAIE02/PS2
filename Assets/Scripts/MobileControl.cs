using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class MobileControl : MonoBehaviour
{
    public float velocidad;
    public float velocidadSalto;
    public static bool CanMove;

    public Transform CheckGroundTf;
    public Rigidbody2D rigi;

    void Start()
    {
        CanMove = true;
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanMove)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector2 moveToRigi = new Vector2(h * velocidad, rigi.velocity.y);

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
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
}
