using UnityEngine;

public class Soul : CollectableObjects
{
    [SerializeField] private int SoulValue = 1;
    protected override void Collect()
    {
        GameManager.Instance.AddSoul(SoulValue);
        Destroy(gameObject);
    }
}
