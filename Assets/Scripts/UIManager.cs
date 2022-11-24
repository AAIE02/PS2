using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance;
    public static UIManager MyInstance
    {
        get
        {
            if (Instance == null)
                Instance = new UIManager();
            return Instance;
        }
    }

    [SerializeField] TextMeshProUGUI txtSouls, txtVictoryCondition;
    [SerializeField] GameObject victoryCondition;

    int Score;
    int WinCondition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           DestroyImmediate(this);
        }
    }

    public void SoulUI(int _soulValue, int _winCondition)
    {
        txtSouls.text = "Souls: " + _soulValue + " / " + _winCondition;
    }

    public void ShowWinCondition(int _soulValue, int _winCondition)
    {
        victoryCondition.SetActive(true);
        txtVictoryCondition.text = "You need " + (_winCondition - _soulValue) + " more souls";
    }
    public void HideWinCondition()
    {
        victoryCondition.SetActive(false);
    }
}
