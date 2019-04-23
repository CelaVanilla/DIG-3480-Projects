using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeed : MonoBehaviour
{

    private ParticleSystem ps;
    private int score;
    private GameController gc;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        var main = ps.main;

        if (gc.victory == true)
        {
            if(main.simulationSpeed >= -20)
            {
                main.simulationSpeed += Time.deltaTime;
            }
        }
    }


    //public void AddScore(int newScoreValue)
    //{
    //   score += newScoreValue;
    //   UpdateScore();
    // }

    // void UpdateScore()
    // {
    //    if (score >= 100)
    //    {
    //        var main = ps.main;
    //       main.simulationSpeed += Time.deltaTime;
    //  }
    // }
}
