using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileControl : MonoBehaviour
{
    [Header("Jump-Movement")]
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadSalto;
    public bool canMove;
    public bool canAttack;
    [SerializeField] public Transform CheckGroundTf;
    [SerializeField] public Rigidbody2D rigi;

    [Header("Animation")]
    private int ah_velocidad = Animator.StringToHash("Velocidad");
    private int ah_heavyattack = Animator.StringToHash("HeavyAttack");
    private int ah_jump = Animator.StringToHash("IsGrounded");
    private int ah_slide = Animator.StringToHash("IsSliding");
    private int ah_spinJump = Animator.StringToHash("IsSpinJump");
    private Animator animator;
    public GameObject attackCol;

    [Header("Slide")]
    [SerializeField] private float slideVelocity;
    [SerializeField] private float slideTime;
    [SerializeField] private TrailRenderer tracking;
    private float initialGravity;
    private bool canSlide = true;

    void Start()
    {
        canAttack = false;
        canMove = true;
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
                animator.SetTrigger(ah_jump);
                Collider2D col = Physics2D.OverlapCircle(CheckGroundTf.position, 0.1f);
                if (col)
                {
                    moveToRigi.y = velocidadSalto;
                }
            }
            if (CrossPlatformInputManager.GetButton("Hit") && CheckGroundTf && canAttack)
            {
                animator.SetTrigger(ah_heavyattack);
                Debug.Log("Diste un golpe");
            }
            rigi.velocity = moveToRigi;
            FlipControl(h);
        }
        if (CrossPlatformInputManager.GetButton("Slide") && canSlide)
        {
            StartCoroutine(Dash());
            Debug.Log("Te deslizaste");
        }

        if (CrossPlatformInputManager.GetButton("SpinJump"))
        {
            animator.SetTrigger(ah_spinJump);
            Debug.Log("Rodaste");
        }
    }

    private IEnumerator Dash()
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
    
    void FlipControl(float h)
    {
        Vector3 escalaActual = transform.localScale;
        if (h != 0)
        {
            escalaActual.x = h > 0f ? 1f : -1f;
        }
        transform.localScale = escalaActual;
    }
    public void Ataca()
    {
        canMove = false;
        attackCol.SetActive(true);
        canAttack = false;
    }
    public void DejaDeAtacar()
    {
        canMove = true;
        attackCol.SetActive(false);
        canAttack = true;
    }
}
