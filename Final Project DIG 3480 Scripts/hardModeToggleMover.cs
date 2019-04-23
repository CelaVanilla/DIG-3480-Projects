using UnityEngine;
using System.Collections;

public class hardModeToggleMover : MonoBehaviour
{
    public float speed;
    private GameController gc;
    private PlayerController pc;
    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        // gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        // pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}

    //void Update()
    //{
        //if (gc.hardMode == true)
        //{
         //   if (speed >= -10f)
           // {
            //    speed -= Time.deltaTime;
             //   rb.velocity = transform.forward * speed;
            //}
           // gc.HardDifficulty();
       // }
   // }
//}
