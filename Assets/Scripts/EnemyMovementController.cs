using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform controladorDePlataforma;
    [SerializeField] private float distance;
    [SerializeField] private bool movimientoDerecha;
    private Rigidbody2D rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoPlataform = Physics2D.Raycast(controladorDePlataforma.position, Vector2.down, distance);
        rigi.velocity = new Vector2(velocity, rigi.velocity.y);
        if (infoPlataform == false)
        {
            FlipControlEnemy();
        }
    }

    void FlipControlEnemy()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(controladorDePlataforma.transform.position, controladorDePlataforma.transform.position + Vector3.down * distance);
    }

}
