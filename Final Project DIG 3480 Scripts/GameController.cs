using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GameObject[] buff;
    public int hazardCount2;
    public float spawnWait2;
    public float startWait2;
    public float waveWait2;
    public Vector3 spawnValues2;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    public AudioSource BgMusic;
    public AudioSource VMusic;
    public AudioClip victoryClip;
    public AudioClip backgroundClip;
    private bool paused1;
    private bool paused2;

    private VictoryMusicTrigger vm;
    private hardModeToggleMover mover;
    private bool gameOver;
    private bool restart;
    public bool victory;
    private int score;
    //public bool hardMode;

    void Start()
    {
        gameOver = false;
        restart = false;
        victory = false;
        //hardMode = false;
        restartText.text = "Press 'V' for Hard Mode";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        StartCoroutine(Buffs());
        BgMusic = GetComponent<AudioSource>();


        VMusic.clip = victoryClip;
        BgMusic.clip = backgroundClip;
        BgMusic.Play(0);

        //AudioSource[] audiosources = GetComponents<AudioSource>();
        //BgMusic = audiosources[0];
        //victoryClip = audiosources[1].clip;
        //backgroundClip = audiosources[0].clip;


    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SceneManager.LoadScene("Hard mode");
            restartText.text = "Hard Mode activated!";
            Debug.Log("Hard Mode Inputted");

        }

        //SCRAPPED BOOL METHOD
        //if (hardMode)
        // {
        //    if (Input.GetKeyDown(KeyCode.V))
        //    {
        //       HardDifficulty();
        //mover.speed = -10;
        //    }
        // }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Z' for Restart";
                restart = true;
                break;
            }
        }
    }

    IEnumerator Buffs()
    {
        yield return new WaitForSeconds(startWait2);
        while (true)
        {
            for (int i = 0; i < hazardCount2; i++)
            {
                GameObject boost = buff[Random.Range(0, buff.Length)];
                Vector3 spawnPosition2 = new Vector3(Random.Range(-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
                Quaternion spawnRotation2 = Quaternion.identity;
                Instantiate(boost, spawnPosition2, spawnRotation2);
                yield return new WaitForSeconds(spawnWait2);
            }
            yield return new WaitForSeconds(waveWait2);

            if (gameOver)
            {
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "GAME CREATED BY ALEC VILLENA";
            gameOver = true;
            restart = true;
            victory = true;
            Music();
        }
    }

    void Music()
    {
        VMusic.clip = victoryClip;
        BgMusic.Pause();
        VMusic.Play(0);

        //BgMusic.PlayOneShot(victoryClip);
        //BgMusic.Pause(backgroundClip);
    }

   // public void HardDifficulty()
    //{
     //   restartText.text = "Hard Mode activated!";
     //   Debug.Log("Hard Mode Inputted");
    //}

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

        if (gameOver == true)
        {
            BgMusic.Pause();
        }
        
    }
}
