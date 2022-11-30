using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinCondition : MonoBehaviour
{
    [SerializeField] private GameObject menuWinCondition;
    [SerializeField] private bool GameHasEnded = false;
    private GameManager GM;
    public float Delay = 3f;

    private void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<GameManager>();
        GM.PlayerWins += ActivateMenu;
        Debug.Log(menuWinCondition, menuWinCondition);
    }

    public void ActivateMenu(object sender, EventArgs e)
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            Debug.Log("GameOver");

            // In general in order to avoid typos I would prefer to use "nameof"
            Invoke(nameof(Finish), Delay);
        }

        Debug.Log(menuWinCondition, menuWinCondition);
        menuWinCondition.SetActive(true);
    }
    public void OnDestroy()
    {
        if(GM)
            GM.PlayerWins -= ActivateMenu;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    /*public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }*/
}
