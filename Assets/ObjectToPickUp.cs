using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToPickUp : MonoBehaviour
{
    [SerializeField] Collider collider;
    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            collider.enabled=false;

            if (gameObject.layer == LayerMask.NameToLayer("Stick"))
            {
                Debug.Log("IncrementingSticks call from object");
                scoreKeeper.IncrementSticks();
            }
            else if (gameObject.layer == LayerMask.NameToLayer("Stone"))
            {
                Debug.Log("IncrementingStones call from object");
                scoreKeeper.IncrementStones();
            }
            
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
