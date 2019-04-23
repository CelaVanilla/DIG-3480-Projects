using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSizeZ;
    private int score;
    //private int speedup = 1;

    private GameController gc;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        score = 0;
    }

    void Update()
    {
        if (gc.victory == true)
        {
            if (scrollSpeed >= -20)
            {
                scrollSpeed -= Time.deltaTime;
            }
        }

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }


    //Unoptimized script below. It worked for a while but ran into errors once I kept reusing the same method
    
    //public void AddScore(int newScoreValue)
   // {
    //    score += newScoreValue;
       // UpdateScore();
   // }

   // void UpdateScore()
    //{
        //if (score >= 100)
       // {
          //  if (scrollSpeed >= -15)
          //  {
             //   scrollSpeed -= Time.deltaTime;
            //}


            //scrollSpeed = -3;
            //float scrollSpeedMultiplier = (int)Time.timeSinceLevelLoad / speedup;
            //float newPosition = Mathf.Repeat(Time.time * scrollSpeed * scrollSpeedMultiplier, tileSizeZ);
            //transform.position = startPosition + Vector3.forward * newPosition;
        //}
   // }
}
