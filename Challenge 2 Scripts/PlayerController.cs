using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public Text winText;
    public Text loseText;
    public Text hp;
    public Text scoreText;
    private int health = 3;
    private int score = 0;
    private GameObject player;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        winText.text = "";
        loseText.text = "";
        SetScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
            Health();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            health = health - 1;
            Health();
        }

    }

    void Health()
    {
        if (health == 0)
        {
            loseText.text = "You Lose...";
            player = GameObject.FindWithTag("Player");
            player.gameObject.SetActive(false);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        hp.text = "Health: " + health.ToString() + " HP";

        if (score == 4)
        {
            health = 3;
            transform.position = -new Vector2(-41.25f, 0f);
        }
        if (score >= 8)
        {
            winText.text = "You Win!";
        }
    }
}
