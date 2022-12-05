using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float HitDamage;
    [SerializeField] private float Vida;
    [SerializeField] private float VidaActualDelEnemigo;
    [SerializeField] private float SpinJumpDamage;

    void Start()
    {
        VidaActualDelEnemigo = Vida;
    }

    void Update()
    {
        if(VidaActualDelEnemigo <= 0)
        {
            Destroy(gameObject,1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AtaqueJugador"))
        {
            VidaActualDelEnemigo -= HitDamage;
            if (collision.gameObject.CompareTag("SpinJumpCollider"))
            {
                VidaActualDelEnemigo -= SpinJumpDamage;
                Debug.Log(VidaActualDelEnemigo);
            }
        }
    }
}