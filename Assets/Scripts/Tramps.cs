using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramps : MonoBehaviour
{

    [SerializeField] private float timePerDamage;

    private float timeNextDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CineMachineCamara.Instance.MoveCamera(5, 5, 0.3f);
            timeNextDamage -= Time.deltaTime;
            if(timeNextDamage <= 0)
            {
                collision.GetComponent<Hp>().TakeDamage(5);
                timeNextDamage = timePerDamage;
            }
        }
    }
}
