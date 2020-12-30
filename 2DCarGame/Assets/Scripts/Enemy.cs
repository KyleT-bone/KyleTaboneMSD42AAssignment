using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 500f;

    // Reduces health whenever enemy collides with a gameObject which has a DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // Access the DamageDealer class from "otherObject" which hits enemy and reduce health accordingly
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        health -= dmgDealer.GetDamage();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
