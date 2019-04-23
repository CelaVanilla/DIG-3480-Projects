using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 1.2f;
    public GameObject powerUpEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        PlayerController speedUp = player.GetComponent<PlayerController>();
        speedUp.fireRate = 0.20f;
        speedUp.speed = 11f;
        //speedUp.speed *= multiplier;

        Instantiate(powerUpEffect, transform.position, transform.rotation);

        Debug.Log("Power Up Acquired");
        Destroy(gameObject);
    }

}
