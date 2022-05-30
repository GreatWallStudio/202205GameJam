using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Material material;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate;
    [SerializeField] bool firing;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float rotationSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] float movementDrag;
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] GameManager gameManager; 
    private Vector3 newRotation = new Vector3(0, 0, 0);
    Vector3 previousAimDirection;
    Vector3 aimDirection;
    private bool doubleKeyPressDetectedPlayer = false; 
    private bool doubleKeyPressDetectedTurret = false;
    [SerializeField] Texture aWTex; 
    [SerializeField] Texture wDTex; 
    [SerializeField] Texture dSTex; 
    [SerializeField] Texture sATex;
    [SerializeField] Texture wTex; 
    [SerializeField] Texture sTex; 
    [SerializeField] Texture aTex; 
    [SerializeField] Texture dTex;
    private bool pauseDelay;

    private void Start()
    {
        rigidbody.drag = movementDrag;
        previousAimDirection = transform.eulerAngles;
    }

    public void Die()
    {
        
    }

    void Update()
    {
        //check for pause keypress
        if (Input.GetKey(KeyCode.P))
        {
            //put a delay on the pause
            if (!pauseDelay)
            {
                gameManager.PauseTheGame();
                StartCoroutine("Pause"); 
                pauseDelay = true; 
            }
        }
        //check for double-key presses
        //aw
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(-transform.right * movementSpeed * 0.7f);
            rigidbody.AddForce(transform.forward * movementSpeed * 0.7f);
            material.mainTexture = aWTex; 
            doubleKeyPressDetectedPlayer = true; 
        }
        //wd
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(transform.forward * movementSpeed * 0.7f);
            rigidbody.AddForce(transform.right * movementSpeed * 0.7f);
            material.mainTexture = wDTex;
            doubleKeyPressDetectedPlayer = true; 
        }
        //ds
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(transform.right * movementSpeed * 0.7f);
            rigidbody.AddForce(-transform.forward * movementSpeed * 0.7f);
            material.mainTexture = dSTex;
            doubleKeyPressDetectedPlayer = true;
        }
        //sa
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(-transform.forward * movementSpeed * 0.7f);
            rigidbody.AddForce(-transform.right * movementSpeed * 0.7f);
            material.mainTexture = sATex;
            doubleKeyPressDetectedPlayer = true;
        }

        //if a double key press was not detected, then check for single key presses
        if (!doubleKeyPressDetectedPlayer)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.forward * movementSpeed);
                material.mainTexture = wTex;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rigidbody.AddForce(-transform.forward * movementSpeed);
                material.mainTexture = sTex;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody.AddForce(-transform.right * movementSpeed);
                material.mainTexture = aTex;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody.AddForce(transform.right * movementSpeed);
                material.mainTexture = dTex;
            }
        }
        else //if it was set to true, then set it back to false 
        {
            doubleKeyPressDetectedPlayer = false; 
        }

        //turret controls
        //check double key presses 
        // left up
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            //change aim from current aim toward -45 
            if (previousAimDirection.y < 135)
            {
                aimDirection = new Vector3(0, -45, 0);
            }
            else
            {
                aimDirection = new Vector3(0, 315, 0);
            }
            newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
            previousAimDirection = newRotation;
            turret.transform.eulerAngles = newRotation;
            doubleKeyPressDetectedTurret = true;
        }
        // up right
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //change aim from current aim toward 45 
            if (previousAimDirection.y < 225)
            {
                aimDirection = new Vector3(0, 45, 0);
            }
            else
            {
                aimDirection = new Vector3(0, 405, 0);
            }
            newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
            previousAimDirection = newRotation;
            turret.transform.eulerAngles = newRotation;
            doubleKeyPressDetectedTurret = true;
        }

        // right down
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            //change aim from current aim toward 135 
            if (previousAimDirection.y > -45)
            {
                aimDirection = new Vector3(0, 135, 0);
            }
            else
            {
                aimDirection = new Vector3(0, -225, 0);
            }
            newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
            previousAimDirection = newRotation;
            turret.transform.eulerAngles = newRotation;
            doubleKeyPressDetectedTurret = true;
        }
        //down left
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            //change aim from current aim toward 225 
            if (previousAimDirection.y > 45)
            {
                aimDirection = new Vector3(0, 225, 0);
            }
            else
            {
                aimDirection = new Vector3(0, -135, 0);
            }
            newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
            previousAimDirection = newRotation;
            turret.transform.eulerAngles = newRotation;
            doubleKeyPressDetectedTurret = true;
        }

        if (!doubleKeyPressDetectedTurret)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //change aim from current aim toward -90 
                if (previousAimDirection.y < 90)
                {
                    aimDirection = new Vector3(0, -90, 0);
                }
                else
                {
                    aimDirection = new Vector3(0, 270, 0);
                }
                newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
                previousAimDirection = newRotation;
                turret.transform.eulerAngles = newRotation;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //change aim from current aim toward 0 
                if (previousAimDirection.y < 180)
                {
                    aimDirection = new Vector3(0, 0, 0);
                }
                else
                {
                    aimDirection = new Vector3(0, 360, 0);
                }
                newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
                previousAimDirection = newRotation;
                turret.transform.eulerAngles = newRotation;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //change aim from current aim toward -90 
                if (previousAimDirection.y > -90)
                {
                    aimDirection = new Vector3(0, 90, 0);
                }
                else
                {
                    aimDirection = new Vector3(0, -270, 0);
                }
                newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
                previousAimDirection = newRotation;
                turret.transform.eulerAngles = newRotation;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //change aim from current aim toward 0 
                if (previousAimDirection.y > 0)
                {
                    aimDirection = new Vector3(0, 180, 0);
                }
                else
                {
                    aimDirection = new Vector3(0, -180, 0);
                }
                newRotation = Vector3.Lerp(previousAimDirection, aimDirection, rotationSpeed * Time.deltaTime);
                previousAimDirection = newRotation;
                turret.transform.eulerAngles = newRotation;
            }
        }
        else
        {
            doubleKeyPressDetectedTurret = false; 
        }

        

        if (Input.GetKey(KeyCode.Space))
        {
            //make sure there is at least one projectile available
            if (scoreKeeper.stonesInInventory > 0)
            {
                //limit fire rate
                if (!firing)
                {
                    Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
                    firing = true;
                    scoreKeeper.DecrementStones(); 
                    StartCoroutine("FireDelay");
                }
            }
        }
    }
    private IEnumerator Pause()
    {
        yield return new WaitForSecondsRealtime(1);
        pauseDelay = false;
    }
    public IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireRate);
        firing = false; 
    }
}
