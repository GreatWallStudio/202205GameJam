using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreKeeper : MonoBehaviour
{
    public bool gameOn = true; 
    public int scoreCount = 0; 
    public int xPCount = 0;    
    public int stonesInInventory = 0; 
    public int sticksInInventory = 0;
    public int deaths = 3;
    public int lives = 3;
    public int level = 1;

    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text xPUI;
    [SerializeField] TMP_Text sticksUI; 
    [SerializeField] TMP_Text stonesUI;
    [SerializeField] TMP_Text deathsUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text levelUI;
    [SerializeField] GameObject theScreenOfDeath;
    [SerializeField] GameManager gameManager; 
    [SerializeField] PlayerController playerController; 

    void updateScoreboard()
    {
        scoreUI.text = scoreCount.ToString();
        xPUI.text = xPCount.ToString();
        livesUI.text = lives.ToString();
        deathsUI.text = deaths.ToString();
        levelUI.text = level.ToString();
        sticksUI.text = sticksInInventory.ToString();
        stonesUI.text = stonesInInventory.ToString();
        if (lives == 0)
        {
            //kill player
            playerController.Die();
            gameManager.EndTheGame();

            //stop the game
            gameOn = false; 
        }
    }

    private void Update()
    {

    }

    public void StartGame()
    {
        gameOn = true;
    }

    public void ReStartGame()
    {
        scoreCount = 0;
        xPCount = 0;
        stonesInInventory = 0;
        sticksInInventory = 0;
        deaths = 3;
        lives = 3;
        level = 1;
        updateScoreboard();
        StartGame();
    }

    public void StopGame()
    {
        gameOn = false; 
    }



    public void IncrementScore()
    {
        scoreCount++;
        updateScoreboard();
    }

    public void DecrementScore()
    {
        scoreCount--;
        updateScoreboard();
    }

    public void IncrementXP()
    {
        xPCount++;
        updateScoreboard();
    }

    public void DecrementXP()
    {
        if (xPCount > 0)
        {
            xPCount--;
            updateScoreboard();
        }
    }
    public void IncrementLives()    {
        lives++;
        updateScoreboard(); 
    }
    public void DecrementLives()    {
        if (lives > 0)
        {
            lives--;
            updateScoreboard();
        }
    }
    public void IncrementDeaths()    {
        deaths++;
        updateScoreboard(); 
    }
    public void DecrementLDeaths()    {
        deaths--;
        updateScoreboard(); 
    }
    public void IncrementLevel()    {
        level++;
        updateScoreboard(); 
    }
    public void DecrementLevel()    {
        level--;
        updateScoreboard(); 
    }
    public void IncrementSticks()    {
        sticksInInventory++;
        updateScoreboard(); 
    }
    public void DecrementSticks()    {
        sticksInInventory--;
        updateScoreboard(); 
    }
    public void IncrementStones()    {
        stonesInInventory++;
        updateScoreboard(); 
    }
    public void DecrementStones()    {
        if (stonesInInventory > 0)
        {
            stonesInInventory--;
            updateScoreboard();
        }
    }
}
