using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonShootingEnemy : MonoBehaviour
{

    [SerializeField] float health = 500f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip enemyDeathSound;
    // Allows the variable to be set in the Inspector from 0 to 1
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;

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
            Die();
        }
    }

    private void Die()
    {
        // Destroy the enemy
        Destroy(gameObject);
        // Instantiate explosion effects
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);
        // Destroy after 1 second
        Destroy(explosion, explosionDuration);
    }


}
