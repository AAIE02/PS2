using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Souls { get; private set; }      //Monedas
    public int SacredSoul { get; private set; }  //Vidas
    public int world { get; private set; }
    public int stage { get; private set; }

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
        // TODO: show game over screen
        SceneManager.LoadScene("GameOver");
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

    public void AddSoul()   //Agrega Monedas
    {
        Souls++;

        if (Souls == 100)
        {
            Souls = 0;
            AddSacredSoul();
        }
    }

    public void AddSacredSoul() //agrega 1 vida al player
    {
        SacredSoul++;
    }
}
