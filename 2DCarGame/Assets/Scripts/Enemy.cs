using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 500f;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyBulletPrefab;

    [SerializeField] float enemyBulletSpeed = 0.3f;

    // Reduces health whenever enemy collides with a gameObject which has a DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // Access the DamageDealer class from "otherObject" which hits enemy and reduce health accordingly
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        // If there is no dmgDealer in otherObject, end the method
        if (!dmgDealer) // if (dmgDealer == null)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    // Whenever ProcessHit is called, send us the DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Generate a random number
        shotCounter = Random.RandomRange(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Update()
    {
        CountdownAndShoot();
    }

    private void CountdownAndShoot()
    {
        // Every frame reduce the amount of time for shot
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            EnemyFire();
            // Reset shotCounter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        // Spawn an enemyBullet at Enemy position
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);

        enemyBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }
}
