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
    //float dirX;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI lose;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerHealth.text = "Health: 3";
        lose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.acceleration.x > 0) 
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
        //playVel.x = dirX;
        rigidbody.velocity = playVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();
        }

        if (collision.gameObject.tag.Equals("Platform") && Physics2D.Linecast(transform.position, transform.position + Vector3.down)) 
        {
            jumpSound.Play();
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
        health -= 1;

        playerHealth.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            Die();
        }

        StartCoroutine(Invincible());
    }

    private void Die() 
    {
        Destroy(gameObject);

        lose.gameObject.SetActive(true);

        //StartCoroutine(Restart());

        SceneManager.LoadScene("Bunny Jump");
    }

    IEnumerator Restart() 
    {
        yield return new WaitForSeconds(3.0f);
    }




}
