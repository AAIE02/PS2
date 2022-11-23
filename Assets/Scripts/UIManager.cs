using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI text;
    int Score;
    //int WinCondition;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    //public void ChangeScore(int soulValue, int winCondition)
    public void ChangeScore(int soulValue)
    {
        //WinCondition += winCondition;
        Score += soulValue;
        text.text = "X" + Score.ToString();
    }
}
