using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfLooseStonesToSpawn;
    [SerializeField] int numberOfSticksToSpawn;
    [SerializeField] int numberOfTreesToSpawn;
    [SerializeField] int numberOfEnemiesToSpawn;
    [SerializeField] bool gameStarted;
    [SerializeField] bool gamePaused;
    [SerializeField] GameObject looseStone;
    [SerializeField] GameObject looseStick;
    [SerializeField] GameObject treeOfLife1;
    [SerializeField] GameObject treeOfLife2;
    [SerializeField] GameObject treeOfLife3;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnedObjectsLocation;
    [SerializeField] Renderer gameAreaRenderer;
    [SerializeField] Canvas titleCanvas;
    [SerializeField] GameObject startButton; 
    [SerializeField] GameObject restartButton; 
    [SerializeField] GameObject playAgain;
    [SerializeField] ScoreKeeper scoreKeeper; 

    // Start is called before the first frame update
    void Start()
    {
        ShowTitleScreen(); 
    }

    public void ShowTitleScreen()
    {
        //show title screen 
        startButton.SetActive(true);
        restartButton.SetActive(false);
        playAgain.SetActive(false);
        titleCanvas.gameObject.SetActive(true); 
    }

    public void ReStartTheGame()
    {
        //delete all trees, rocks, enemies, etc.
        foreach (Transform child in spawnedObjectsLocation)
        {
            GameObject.Destroy(child.gameObject); 
        }

        StartTheGame(); 
        scoreKeeper.ReStartGame();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartTheGame()
    {
        Debug.Log("Starting the Game"); 
        SpawnLooseStones();
        SpawnSticks();
        SpawnTrees();
        SpawnEnemies();
        titleCanvas.gameObject.SetActive(false);
        gameStarted = true; 
    }
    public void PauseTheGame()
    {
        if (!gamePaused)
        {
            startButton.SetActive(false);
            restartButton.SetActive(true);
            playAgain.SetActive(false);
            titleCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else
        {
            UnPauseTheGame(); 
        }
    }

    public void UnPauseTheGame()
    {
        titleCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }
    public void EndTheGame()
    {
        startButton.SetActive(false);
        restartButton.SetActive(false);
        playAgain.SetActive(true);
        gameStarted = false;
        titleCanvas.gameObject.SetActive(true); 
    }

    private void SpawnTrees()
    {
        for (int i = 0; i < (numberOfTreesToSpawn); i++)
        {
//            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), 5f, UnityEngine.Random.Range(-100,100)); 
            Instantiate(treeOfLife1, spawnPoint, Quaternion.Euler(0,0,0), spawnedObjectsLocation);

            //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
            Instantiate(treeOfLife2, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);

            //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
            Instantiate(treeOfLife3, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), .5f, UnityEngine.Random.Range(-100, 100));
            Instantiate(enemy, spawnPoint, Quaternion.Euler(90, 0, 0), spawnedObjectsLocation);
        }
    }

    private void SpawnLooseStones()
    {
        for (int i = 0; i < numberOfLooseStonesToSpawn; i++)
        {
//            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), .5f, UnityEngine.Random.Range(-100,100)); 
            Instantiate(looseStone, spawnPoint, Quaternion.Euler(90,0,0), spawnedObjectsLocation);
        }
    }
    private void SpawnSticks()
        {
            for (int i = 0; i < numberOfSticksToSpawn; i++)
            {
    //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), .5f, UnityEngine.Random.Range(-100,100)); 
                Instantiate(looseStick, spawnPoint, Quaternion.Euler(90,0,0), spawnedObjectsLocation);
            }
        }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
