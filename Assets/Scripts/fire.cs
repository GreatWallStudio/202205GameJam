using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody; 
    [SerializeField] float projectileSpeed; 

    void OnEnable()
    {
        rigidbody.AddForce(transform.up * projectileSpeed);
        //StartCoroutine("FizzleOut"); 
    }

    public IEnumerator FizzleOut()
    {
        yield return new WaitForSeconds(2);
      //  Destroy(gameObject); 
    }
}
