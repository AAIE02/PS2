using UnityEngine;
public class Acantilado : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.ResetLevel(2f);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}