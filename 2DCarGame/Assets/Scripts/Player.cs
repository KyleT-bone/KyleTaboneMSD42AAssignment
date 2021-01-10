using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Makes the variable editable on Unity Editor
    [SerializeField] float movementSpeed = 10f;

    [SerializeField] float health = 50f;

    [SerializeField] AudioClip playerDeathSound;
    // Allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    /*Coroutine firingCoroutine;*/

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        ViewPortToWorldPoint();
        //StartCoroutine(PrintAndWait());
    }

    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.1f, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.9f, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 0.2f, 0)).y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        /*Fire();*/
    }

    // moves the Player ship
    private void Move()
    {
        /* var changes its variable type depending on
        what I save in it.
        deltaX will have the difference in the x-axis
        wich the Player moves*/
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;

        // newXPos  = current x-position   + difference in x
        var newXPos = transform.position.x + deltaX;

        // Clamp the ship between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        // the above in y axis:
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        var newYPos = transform.position.y + deltaY;

        // Clamp the ship between yMin and yMax
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        // move the Player ship to  the newXPos
        this.transform.position = new Vector2(newXPos, newYPos);

    }

    /*Reduses health whenever Player collides with a gameObject
    which has a DamageDealer component*/
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        /*Access the DamageDealer class from "otherObject" which hits player and
         reduce health accordingly*/
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        // If there is no dmgDealer in otherObject, end the method
        if (!dmgDealer) // if (dmgDealer == null)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

// Whenever PricessHit() is called, send us the DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        // To go to the GameOver
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }


}