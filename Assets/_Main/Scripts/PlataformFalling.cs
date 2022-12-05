using System.Collections;
using UnityEngine;


public class PlataformFalling : MonoBehaviour
{
    [SerializeField] private float TimePerPlataform;
    [SerializeField] private float TimeRegenPlata;
    [SerializeField] private AudioClip BreakPlataform;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private BoxCollider2D B2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(StayInPlataform());
    }

    IEnumerator StayInPlataform()
    {
        SpriteRenderer.enabled = true;
        B2.enabled = true;
        yield return new WaitForSeconds(TimePerPlataform);
        SoundManager.Instance.PlaySFX(BreakPlataform);
        SpriteRenderer.enabled = false;
        B2.enabled = false;

        yield return new WaitForSeconds(TimeRegenPlata);
        SpriteRenderer.enabled = true;
        B2.enabled = true;
    }
}