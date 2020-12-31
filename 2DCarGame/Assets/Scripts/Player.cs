using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Makes the variable editable on Unity Editor
    [SerializeField] float movementSpeed = 10f;

    [SerializeField] float health = 50f;

    /*Coroutine firingCoroutine;*/

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        //StartCoroutine(PrintAndWait());
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0.25f, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(0.75f, 0, 0)).x - padding;

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

        ProcessHit(dmgDealer);
}

// Whenever PricessHit() is called, send us the DamageDealer details
private void ProcessHit(DamageDealer dmgDealer)
{
    health -= dmgDealer.GetDamage();

    if (health <= 0)
    {
        Destroy(gameObject);
    }
}

    // Coroutine Example
    /*private IEnumerator PrintAndWait()
    {
        print("Message 1");
        yield return new WaitForSeconds(10);
        print("Message 2 after 10 seconds");
        yield return new WaitForSeconds(20);
        print("Message 2 after 30 seconds");
    }*/

    // If coroutine is started, don't start another one

    /*private IEnumerator FireContinously()
    {
        while (true) // While coroutine is running
        {
            // Create an instance of laserPrefab at the position of the Player Ship
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            // Add a velocity to the laser in the y-axis
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, laserspeed);
            // Wait x seconds before repeating
            yield return new WaitForSeconds(laserFiringTime);
        }
    }*/

    /*private void Fire()
    {
        if (!coroutineStarted) // coroutineStarted == false
        {
            if (Input.GetButtonDown("Fire1"))
            {
                firingCoroutine = StartCoroutine(FireContinously());
                coroutineStarted = true;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
            coroutineStarted = false;
        }*/

        // If fire button is pressed, start Coroutine to fire
    }