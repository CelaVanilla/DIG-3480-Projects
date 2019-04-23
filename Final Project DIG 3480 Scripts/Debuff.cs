using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    public float multiplier = 0.8f;
    public GameObject debuffEffect;

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
        speedUp.fireRate = 0.33f;
        speedUp.speed *= multiplier;

        Instantiate(debuffEffect, transform.position, transform.rotation);

        Debug.Log("Power Up Acquired");
        Destroy(gameObject);
    }

}
