using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private Hp hp;

    private void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Hp>();
        hp.PlayerDeath += ActivateMenu;
    }

    public void ActivateMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
