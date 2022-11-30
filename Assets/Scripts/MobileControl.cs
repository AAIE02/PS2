using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileControl : MonoBehaviour
{
    [Header("Jump-Movement")]
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadSalto;
    [SerializeField] public Transform CheckGroundTf;
    private Rigidbody2D rigi;
    public bool canMove = true;

    [Header("Animation")]
    private int ah_velocidad = Animator.StringToHash("Velocidad");
    private int ah_attack = Animator.StringToHash("IsAttacking");
    private int ah_jump = Animator.StringToHash("IsGrounded");
    private int ah_slide = Animator.StringToHash("IsSliding");
    private int ah_spinJump = Animator.StringToHash("IsSpinJump");
    private Animator animator;
    [SerializeField] private ParticleSystem particles;

    [Header("Slide")]
    [SerializeField] private float slideVelocity;
    [SerializeField] private float slideTime;
    [SerializeField] private TrailRenderer tracking;
    private float initialGravity;
    private bool canSlide = true;

    [Header("SpinJump")]


    [Header("Attack")]
    public GameObject attackCol;
    //private bool canAttack = true;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialGravity = rigi.gravityScale;
    }

    void Update()
    {
        if (canMove)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector2 moveToRigi = new Vector2(h * velocidad, rigi.velocity.y);
            animator.SetInteger(ah_velocidad, Mathf.FloorToInt(Mathf.Abs(h)));

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                particles.Play();
                animator.SetTrigger(ah_jump);
                Collider2D col = Physics2D.OverlapCircle(CheckGroundTf.position, 0.1f);
                if (col)
                {
                    moveToRigi.y = velocidadSalto;
                }
            }
            if (CrossPlatformInputManager.GetButton("Hit")) //&& canAttack
            {
                animator.SetTrigger(ah_attack);
            }
            rigi.velocity = moveToRigi;
            FlipControl(h);
        }
        if (CrossPlatformInputManager.GetButton("Slide") && canSlide)
        {
            StartCoroutine(Slide());
        }

        if (CrossPlatformInputManager.GetButton("SpinJump"))
        {
            animator.SetTrigger(ah_spinJump);
        }
    }

    private IEnumerator Slide()
    {
        canMove = false;
        canSlide = false;
        rigi.gravityScale = 0;
        rigi.velocity = new Vector2(slideVelocity * transform.localScale.x, 0);
        animator.SetTrigger(ah_slide);
        tracking.emitting = true;

        yield return new WaitForSeconds(slideTime);

        canMove = true;
        canSlide=true;
        rigi.gravityScale = initialGravity;
        tracking.emitting = false;
    }
    
    private void FlipControl(float h)
    {
        Vector3 escalaActual = transform.localScale;
        if (h != 0)
        {
            escalaActual.x = h > 0f ? 1f : -1f;
            particles.Play();
        }
        transform.localScale = escalaActual;
    }

    public void Ataca()
    {
        canMove = true;
        attackCol.SetActive(false);
        //canAttack = false;
    }
    public void DejaDeAtacar()
    {
        canMove = false;
        attackCol.SetActive(true);
        //canAttack = true;
    }
}
