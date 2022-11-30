using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public int health = 5;
    Rigidbody2D rigidbody;
    float movement = 0.0f;
    public float speed = 10.0f;
    Vector2 playVel;
    public TextMeshProUGUI playerHealth;
    public GameObject imageHealth;
    public GameObject lose;

    public AudioSource jumpSound;
    public AudioSource healthGrab;
    public AudioSource loseSound;
    public AudioSource playerHit;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerHealth.text = "3";
        imageHealth.gameObject.SetActive(true);
        lose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.x != 0) 
        {
            movement = Input.acceleration.x * speed;
        } else
        {
            movement = Input.GetAxis("Horizontal") * speed;
        }


    }

    private void FixedUpdate()
    {
        playVel = rigidbody.velocity;
        playVel.x = movement;
        rigidbody.velocity = playVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
        }

        if (collision.gameObject.tag.Equals("Heart")) 
        {
            Destroy(collision.gameObject);

            healthGrab.Play();

            health = 3;

            playerHealth.text = health.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet")) 
        {
            Destroy(collision.gameObject);

            TakeDamage();
        }

        if (collision.gameObject.tag.Equals("Destroyer"))
        {
            Die();
        }
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(5.0f);
    }


    private void TakeDamage() 
    {
        playerHit.Play();

        health -= 1;

        playerHealth.text = health.ToString();

        if (health <= 0)
        {
            Die();
        }

        StartCoroutine(Invincible());
    }

    private void Die() 
    {
        loseSound.Play();

        lose.gameObject.SetActive(true);

        StartCoroutine(Restart());

    }

    IEnumerator Restart() 
    {
        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("Bunny Jump");

    }




}
