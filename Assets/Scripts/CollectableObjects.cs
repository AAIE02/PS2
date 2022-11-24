using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        //GameManager.Instance.AddSoul();
        //GameManager.Instance.AddSacredSoul();
        //SoundManager.Instance.PlaySound(Coin);
        //UIManager.Instance.ChangeScore(SoulValue);
        //Destroy(gameObject);
    }
}
