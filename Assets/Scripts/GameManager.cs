using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int TimeToEnd;
    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;
    public int redKey = 0, silverKey = 0, goldKey = 0;
    AudioSource audioSource;
    [SerializeField]
    AudioClip winClip, loseClip, pauseClip, resumeClip, pickupClip;
    public static GameManager gameManager;
    musicScript musicScript;
    const float DEFAULTPITCH = 1f, HIGHERPITCH = 1.5f;
    bool isLessTimeOn = false;


    public Text timeText, goldkeyText, redkeyText, silverkeyText, pointsText, pauseText, reloadText, useText;
    public Image snowflake;
    public GameObject infoPanel;


    //
    //public GameObject panelWinGame; // <- panel
    //public Text textWinGame; // <- tekst
   // public Image image; 



    private void Start()
    {
        
        if (gameManager == null)
        {
            gameManager = this;
        }
        Time.timeScale = 1f;

        //panelWinGame.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        musicScript = GetComponentInChildren<musicScript>();

        InitUI();

        if (TimeToEnd <= 0) {
                TimeToEnd = 100;
            InvokeRepeating("Stopper", 2, 1);
        }



        //DontDestroyOnLoad(this.gameObject);

    }
    private void InitUI()
    {
        timeText.text = TimeToEnd.ToString();
        goldkeyText.text = goldKey.ToString();
        redkeyText.text = redKey.ToString();
        silverkeyText.text = silverKey.ToString();
        pointsText.text = points.ToString();
        snowflake.enabled = false;
        infoPanel.SetActive(false);
        pauseText.text = "Game Paused";
        reloadText.text = "";
        SetUseText("");

    }
    public void SetUseText(string useText)
    {
        this.useText.text = useText;
    }

    private void Update()
    {
        PauseCheck();
        if(endGame)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Application.Quit();
            }

        }
        
    }
    void Stopper()
    {
        TimeToEnd--;
        timeText.text = TimeToEnd.ToString();
        if (snowflake.enabled)
        {
            snowflake.enabled = false;
        }
        Debug.Log($"Time:{TimeToEnd}s");
        if (TimeToEnd <= 0)
        {
            TimeToEnd = 0;
            endGame = true;
        }
        if(TimeToEnd <= 20 && !isLessTimeOn)
        {
            LessTimeOn();
            isLessTimeOn=true;
        }
        if (TimeToEnd > 20 && isLessTimeOn)
        {
            LessTimeOff();
            isLessTimeOn = false;
        }

        if (endGame)
            EndGame();
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
        if (endGame) return;
        
        PlayClip(pauseClip);
        Debug.Log("Game Paused");
        infoPanel.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        if (endGame) return;

        PlayClip(pauseClip);
        Debug.Log("Game Resumed");
        infoPanel.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            
            PlayClip(winClip);
            pauseText.text = "You win!!!";
            Debug.Log("You win! Reload?");

        }
        else
        {
            
            PlayClip(loseClip);
            pauseText.text = "You lose :(";
            Debug.Log("You lose! Reload?");
        }
        reloadText.text = "Reload? Y/N";
        infoPanel.SetActive(true);
        
    }
    public void AddPoints(int points)
    {
        this.points += points;
        pointsText.text = points.ToString();
    }
    public void AddTime(int time)
    {
        TimeToEnd += time;
        timeText.text = TimeToEnd.ToString();
    }
    public void FreezeTime(int freezetime)
    {
        CancelInvoke("Stopper");
        snowflake.enabled = true;
        InvokeRepeating("Stopper", freezetime, 1);
        
    }
    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red)
        {
            redKey++;
            redkeyText.text = redKey.ToString();
        }
        else if (keyColor == KeyColor.Silver)
        {
            silverKey++;
            silverkeyText.text = silverKey.ToString();
        }
        else if (keyColor == KeyColor.Gold)
        {
            goldKey++;
            goldkeyText.text = goldKey.ToString();
        }
        else Debug.Log("Incorrect key color!");
    }
   public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public  AudioClip GetPickupCLip()
    {
        return pickupClip;
    }

    public void LessTimeOn()
    {
        musicScript.PitchThis(HIGHERPITCH);
    }
    
    public void LessTimeOff()
    {
        musicScript.PitchThis(DEFAULTPITCH);
    }

    public void WinGame()
    {
        win = true;
        endGame = true;
        //panelWinGame.SetActive(true);
        EndGame();
        
    }
    public void SetKeyUI(KeyColor keycolour)
    {
        switch (keycolour  )
        {
            case KeyColor.Red:
                redkeyText.text = redKey.ToString();

                break;
            case KeyColor.Silver:
                silverkeyText.text = silverKey.ToString();
                break;
            case KeyColor.Gold:
                goldkeyText.text = goldKey.ToString();

                break;
            
        }
    }
    
}
