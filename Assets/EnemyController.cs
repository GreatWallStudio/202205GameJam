using System.Collections;
using System.Collections.Generic;using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Transform goal;
    [SerializeField] Collider collider;
    [SerializeField] ScoreKeeper scoreKeeper;

    void Start()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            scoreKeeper.DecrementLives();

        }

    }
}