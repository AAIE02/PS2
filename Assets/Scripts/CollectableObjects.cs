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
        
    }
}