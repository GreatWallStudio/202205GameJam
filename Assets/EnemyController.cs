using System.Collections;
using System.Collections.Generic;using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{


    [SerializeField] BoxCollider collider;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject aliveQuad;
    [SerializeField] GameObject deadQuad;
    [SerializeField] GameObject wolf;

    private ScoreKeeper scoreKeeper;
    private GameObject goal; 
    private bool alive = true;

    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
         collider = GetComponent<BoxCollider>(); 
         scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
         goal = GameObject.Find("Player");
         aliveQuad.gameObject.SetActive(true); 
         deadQuad.gameObject.SetActive(false); 

    }

    private void Update()
    {
        if (alive)
        {
            //navigate toward player
            agent.destination = goal.transform.position;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "ProjectileStone(Clone)")
        {
            collider.enabled = false;
            alive = false;
            agent.isStopped = true; 
            aliveQuad.gameObject.SetActive(false);
            deadQuad.gameObject.SetActive(true);
            //add to score and xp
            scoreKeeper.IncrementScore();
            scoreKeeper.IncrementXP();

            //spawn 2 more enemies nearby after a brief delay
            StartCoroutine("Pause");
        }
        if (other.gameObject.name == "Player")
        {
            scoreKeeper.DecrementLives();
        }
    }
    public IEnumerator Pause()
    {
        yield return new WaitForSeconds(2);

        //for (var n = 1; n < 3; n++)
        //{
        //    var xPos = Random.RandomRange(transform.position.x + 5, transform.position.x - 5);
        //    var yPos = transform.position.y;
        //    var zPos = Random.RandomRange(transform.position.x + 5, transform.position.x - 5);
        //    Vector3 spawnPoint = new Vector3(xPos, yPos, zPos);

        //    Instantiate(wolf, spawnPoint, Quaternion.identity);
        //}
        //die
        Destroy(gameObject);
    }
}