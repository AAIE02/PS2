using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Souls { get; private set; }      //Monedas
    public int SacredSoul { get; private set; }  //Vidas

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
