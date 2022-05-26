using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numberOfLooseStonesToSpawn;
    [SerializeField] int numberOfSticksToSpawn;
    [SerializeField] int numberOfTreesToSpawn;
    [SerializeField] GameObject looseStone;
    [SerializeField] GameObject looseStick;
    [SerializeField] GameObject treeOfLife1;
    [SerializeField] GameObject treeOfLife2;
    [SerializeField] GameObject treeOfLife3;
    [SerializeField] GameObject gameArea;
    [SerializeField] Renderer gameAreaRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        //SpawnTrees();
        SpawnLooseStones();
        SpawnSticks();
        SpawnTrees(); 
        //gameAreaRenderer = gameArea.GetComponent<Renderer>(); 
    }

    private void SpawnTrees()
    {
        for (int i = 0; i < (numberOfTreesToSpawn); i++)
        {
//            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), 5f, UnityEngine.Random.Range(-100,100)); 
            Instantiate(treeOfLife1, spawnPoint, Quaternion.Euler(0,0,0));

            //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
            Instantiate(treeOfLife2, spawnPoint, Quaternion.Euler(0, 0, 0));

            //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            spawnPoint = new Vector3(UnityEngine.Random.Range(-100, 100), 5f, UnityEngine.Random.Range(-100, 100));
            Instantiate(treeOfLife3, spawnPoint, Quaternion.Euler(0, 0, 0));
        }
    }
    
    private void SpawnLooseStones()
    {
        for (int i = 0; i < numberOfLooseStonesToSpawn; i++)
        {
//            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
            var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), .5f, UnityEngine.Random.Range(-100,100)); 
            Instantiate(looseStone, spawnPoint, Quaternion.Euler(90,0,0));
        }
    }
    private void SpawnSticks()
        {
            for (int i = 0; i < numberOfSticksToSpawn; i++)
            {
    //            var spawnPoint = new Vector3(UnityEngine.Random.Range(-(gameAreaRenderer.bounds.size.x/2), gameAreaRenderer.bounds.size.x/2), 0, UnityEngine.Random.Range(gameAreaRenderer.bounds.size.z, gameAreaRenderer.bounds.size.z)); 
                var spawnPoint = new Vector3(UnityEngine.Random.Range(-100,100), .5f, UnityEngine.Random.Range(-100,100)); 
                Instantiate(looseStick, spawnPoint, Quaternion.Euler(90,0,0));
            }
        }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
