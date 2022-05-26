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

            if (name == "LooseStick(Clone)")
            {
                Debug.Log("IncrementingSticks call from object");
                scoreKeeper.IncrementSticks();
            }
            else if (name == "LooseStone(Clone)")
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
