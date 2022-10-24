using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soul : MonoBehaviour
{
    public int SoulValue = 1;
    //[SerializeField] private AudioClip Coin;

    public enum Type
    {
        Coin
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        GameManager.Instance.AddSoul();
        GameManager.Instance.AddSacredSoul();
        //SoundManager.Instance.PlaySound(Coin);
        UIManager.instance.ChangeScore(SoulValue);
        Destroy(gameObject);
    }
}
