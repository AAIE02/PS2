using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MobileControl : MonoBehaviour
{
    [Header("Jump-Movement")]
    [SerializeField] private float velocidad;
    [SerializeField] private float velocidadSalto;
    [SerializeField] private Transform CheckGroundTf;
    private Rigidbody2D rigi;
    [SerializeField] private bool canMove = true;

    [Header("Animation")]
    [SerializeField] private int ah_velocidad = Animator.StringToHash("Velocidad");
    [SerializeField] private int ah_attack = Animator.StringToHash("IsAttacking");
    [SerializeField] private int ah_jump = Animator.StringToHash("IsGrounded");
    [SerializeField] private int ah_slide = Animator.StringToHash("IsSliding");
    [SerializeField] private int ah_spinJump = Animator.StringToHash("IsSpinJump");
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem particles;

    [Header("Slide")]
    [SerializeField] private float slideVelocity;
    [SerializeField] private float slideTime;
    [SerializeField] private TrailRenderer tracking;
    [SerializeField] private float initialGravity;
    [SerializeField] private bool canSlide = true;

    [Header("SpinJump")]


    [Header("Attack")]
    public GameObject attackCol;

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        initialGravity = rigi.gravityScale;
    }

    void Update()
    {
        if (canMove)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Vector2 moveToRigi = new Vector2(h * velocidad, rigi.velocity.y);
            _animator.SetInteger(ah_velocidad, Mathf.FloorToInt(Mathf.Abs(h)));

            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                particles.Play();
                _animator.SetTrigger(ah_jump);
                Collider2D col = Physics2D.OverlapCircle(CheckGroundTf.position, 0.1f);
                if (col)
                {
                    moveToRigi.y = velocidadSalto;
                }
            }
            if (CrossPlatformInputManager.GetButton("Hit")) //&& canAttack
            {
                _animator.SetTrigger(ah_attack);
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
            _animator.SetTrigger(ah_spinJump);
        }
    }

    private IEnumerator Slide()
    {
        canMove = false;
        canSlide = false;
        rigi.gravityScale = 0;
        rigi.velocity = new Vector2(slideVelocity * transform.localScale.x, 0);
        _animator.SetTrigger(ah_slide);
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
    }
    public void DejaDeAtacar()
    {
        canMove = false;
        attackCol.SetActive(true);
    }
}
