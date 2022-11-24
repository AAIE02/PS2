using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soul : CollectableObjects
{
    [SerializeField] private int SoulValue = 1;


    protected override void Collect()
    {
        GameManager.Instance.AddSoul(SoulValue);
        Destroy(gameObject);
    }
}
