using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI text;
    int soul;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int coinValue)
    {
        soul += coinValue;
        text.text = "X" + soul.ToString();
    }
}
