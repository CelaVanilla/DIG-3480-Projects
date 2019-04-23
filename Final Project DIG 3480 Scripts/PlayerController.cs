using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rb;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.25f;
    private int powerOnOff;
    //public bool hardMode;
    private float nextFire;
    private AudioSource audioSource;
    private GameController gc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        powerOnOff = 0;
        //hardMode = false;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
       // if (hardMode)
       // {
           // if (Input.GetButton("Jump"))
           // {
            //    gc.HardDifficulty();
                //mover.speed = -10;
          //  }
        //}
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
             Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
             0.0f,
             Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

   // public void PowerUp (int activate)
   // {
    //    powerOnOff += activate;
     //   SpeedBoost();
   // }

    //void SpeedBoost()
    //{
    //    if (powerOnOff >= 1)
    //    {
    //        fireRate = 2 / 4;
    //        speed = 15;
    //    }
   // }
}

