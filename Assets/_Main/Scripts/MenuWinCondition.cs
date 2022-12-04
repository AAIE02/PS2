using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWinCondition : MonoBehaviour
{
    [SerializeField] private GameObject menuWinCondition;
    [SerializeField] private bool GameHasEnded = false;
    [SerializeField] private float Delay = 3f;
    private GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("gameManager").GetComponent<GameManager>();
        GM.PlayerWins += ActivateMenu;
    }

    public void ActivateMenu(object sender, EventArgs e)
    {
        if (!GameHasEnded)
        {
            GameHasEnded = true;
            // In general in order to avoid typos I would prefer to use "nameof"
            Invoke(nameof(Finish), Delay);
        }
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
}
