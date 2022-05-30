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
    public bool gameStarted;
    public bool gamePaused;
    [SerializeField] GameObject stoneOfLife;
    [SerializeField] GameObject stoneOfDeath;
    [SerializeField] GameObject looseStick;
    [SerializeField] GameObject treeOfLife1;
    [SerializeField] GameObject treeOfLife2;
    [SerializeField] GameObject treeOfLife3;
    [SerializeField] GameObject treeOfDeath1;
    [SerializeField] GameObject treeOfDeath2;
    [SerializeField] GameObject treeOfDeath3;
    [SerializeField] Renderer groundPlaneOfLife;
    [SerializeField] Renderer groundPlaneOfDeath;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnedObjectsLocation;
    [SerializeField] Renderer gameAreaRenderer;
    [SerializeField] Canvas titleCanvas;
    [SerializeField] GameObject startButton; 
    [SerializeField] GameObject restartButton; 
    [SerializeField] GameObject playAgain;
    [SerializeField] TMP_Text transitionText;
    [SerializeField] GameObject titleScreenOfLife; 
    [SerializeField] GameObject titleScreenTransition; 
    [SerializeField] GameObject titleScreenOfDeath; 
    [SerializeField] ScoreKeeper scoreKeeper;
    public int worldType = 1; 

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
        titleScreenOfLife.SetActive(true);
        titleScreenTransition.SetActive(false);
        titleScreenOfDeath.SetActive(false);
        transitionText.gameObject.SetActive(false);
        titleCanvas.gameObject.SetActive(true); 
    }

    public void ReStartTheGame()
    {
        //delete all trees, rocks, enemies, etc.
        foreach (Transform child in spawnedObjectsLocation)
        {
            GameObject.Destroy(child.gameObject); 
        }

        worldType = 1; 
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

    public void SwitchToDeathMode()
    {
        Debug.Log("Starting Death Mode");
        worldType = 2;

        //delete all trees, rocks, enemies, etc.
        foreach (Transform child in spawnedObjectsLocation)
        {
            GameObject.Destroy(child.gameObject);
        }

        startButton.SetActive(false);
        restartButton.SetActive(false);
        playAgain.SetActive(false);
        titleScreenOfLife.SetActive(false);
        titleScreenTransition.SetActive(true);
        titleScreenOfDeath.SetActive(false);
        transitionText.gameObject.SetActive(true); 
        titleCanvas.gameObject.SetActive(true);

        //give some time to read it then get death started
        StartCoroutine("StartDeathMode"); 
    }

    public IEnumerator StartDeathMode()
    {
        yield return new WaitForSeconds(3);

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
            titleScreenTransition.SetActive(false);

            if (worldType == 1)
            {
                titleScreenOfLife.SetActive(true);
                titleScreenOfDeath.SetActive(false);
            }
            else if (worldType == 2)
            {
                titleScreenOfLife.SetActive(false);
                titleScreenOfDeath.SetActive(true);
            }
            transitionText.gameObject.SetActive(false);
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
        transitionText.gameObject.SetActive(false);
        titleScreenOfLife.SetActive(false);
        titleScreenTransition.SetActive(false);
        titleScreenOfDeath.SetActive(true);
        gameStarted = false;
        titleCanvas.gameObject.SetActive(true); 
    }

    private void SpawnTrees()
    {

        for (int i = 0; i < (numberOfTreesToSpawn); i++)
        {
            if (worldType == 1)
            {
                groundPlaneOfLife.gameObject.SetActive(true); 
                groundPlaneOfDeath.gameObject.SetActive(false); 
                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfLife1, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);

                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfLife2, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);

                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfLife3, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);
            }
            else if (worldType == 2)
            {
                groundPlaneOfLife.gameObject.SetActive(false);
                groundPlaneOfDeath.gameObject.SetActive(true);
                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfDeath1, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);

                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfDeath2, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);

                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(treeOfDeath3, spawnPoint, Quaternion.Euler(0, 0, 0), spawnedObjectsLocation);
            }
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
        if (worldType == 1)
        {
            for (int i = 0; i < numberOfLooseStonesToSpawn; i++)
            {
                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), .5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(stoneOfLife, spawnPoint, Quaternion.Euler(90, 0, 0), spawnedObjectsLocation);
            }
        }
        else if (worldType == 2)
        {
            for (int i = 0; i < numberOfLooseStonesToSpawn; i++)
            {
                //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), .5f, UnityEngine.Random.Range(-100, 100));
                Instantiate(stoneOfDeath, spawnPoint, Quaternion.Euler(90, 0, 0), spawnedObjectsLocation);
            }
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
