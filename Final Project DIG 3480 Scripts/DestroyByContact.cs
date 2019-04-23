using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private BGScroller bgScroller;
    private ParticleSpeed ps;
    //public int powerUp;
    private PlayerController player;
    private VictoryMusicTrigger vm;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

        GameObject bgScrollerObject = GameObject.FindWithTag("BGScroller");
        if (bgScrollerObject != null)
        {
            bgScroller = bgScrollerObject.GetComponent<BGScroller>();
        }

        if (bgScroller == null)
        {
            Debug.Log("Cannot find 'BGScroller' script");
        }

        GameObject particleObject = GameObject.FindWithTag("particles");
        if (particleObject != null)
        {
            ps = particleObject.GetComponent<ParticleSpeed>();
        }

        if (ps == null)
        {
            Debug.Log("Cannot find 'Particle Speed' script");
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("PowerUp"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);

        //SCRAP

        //ps.AddScore(scoreValue);
        //vm.AddScore(scoreValue);
        //bgScroller.AddScore(scoreValue);

        //if (other.CompareTag("PowerUp"))
        //{
            //player.PowerUp(powerUp);
        //}
    }
}
