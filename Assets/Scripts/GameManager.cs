using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int TimeToEnd;
    bool gamePaused = false;
public static GameManager   gameManager;

    private void Start()
    {
       if(gameManager == null)
        {
            gameManager = this;
            if(TimeToEnd <= 0)
                TimeToEnd = 100;
            InvokeRepeating("Stopper", 2, 1);
        }
    }
    private void Update()
    {
        PauseCheck();
    }
    void Stopper()
    {
        TimeToEnd--;
        Debug.Log($"Time:{TimeToEnd}s");
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else PauseGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }
}
