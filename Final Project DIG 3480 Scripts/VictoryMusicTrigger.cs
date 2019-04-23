using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusicTrigger : MonoBehaviour
{
    private AudioSource VictoryMusic;
    private int score;
    private GameController gc;

    void Start()
    {
        VictoryMusic = GetComponent<AudioSource>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    //public void VictoryTrigger()
    //{

    //    VictoryMusic.Play(0);
   // }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        MusicTrigger();
    }

    void MusicTrigger()
    {
        if (score >= 100)
        {
            VictoryMusic.Play(0);
        }
    }

    //void Update()
    //{
     //   if (gc.victory == true)
     //   {
     //       VictoryMusic.Play(0);
      //  }
   // }

}
