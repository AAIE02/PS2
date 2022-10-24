using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    public TextMeshProUGUI text;
    int soul;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int soulValue)
    {
        soul += soulValue;
        text.text = "X" + soul.ToString();
    }
}
