using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Souls { get; private set; }      //Puntos
    public int SacredSoul { get; private set; }  //Vidas
    public int world { get; private set; } 
    public int stage { get; private set; }

    public event EventHandler PlayerWins;
    private int colledtedSouls, victoryCondition = 5;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        UIManager.MyInstance.SoulUI(colledtedSouls, victoryCondition);
        Application.targetFrameRate = 60;
        NewGame();
    }

    public void NewGame()
    {
        SacredSoul = 3;
        Souls = 0;

        LoadLevel(1, 1);
    }

    public void GameOver()
    {

        //SceneManager.LoadScene("GameOver");
        NewGame();
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;

        SceneManager.LoadScene($"{world}-{stage}");
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()        //Reinicia el nivel
    {        
        Souls--;

        if (Souls > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }
       
    public void AddSoul(int _souls)   //Agrega Monedas
    {
        colledtedSouls += _souls;
        UIManager.MyInstance.SoulUI(colledtedSouls, victoryCondition);
    }

    public void AddSacredSoul() //agrega 1 vida al player
    {
        SacredSoul++;
    }

    public void Finish()
    {
        if (colledtedSouls >= victoryCondition)
        {
            PlayerWins?.Invoke(this, EventArgs.Empty);
            SceneManager.LoadScene("1-2");
        }
        else
        {
            UIManager.MyInstance.ShowWinCondition(colledtedSouls, victoryCondition);
        }
    }
}