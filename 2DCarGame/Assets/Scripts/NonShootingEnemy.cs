using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonShootingEnemy : MonoBehaviour
{

    [SerializeField] float health = 500f;

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


    
}
