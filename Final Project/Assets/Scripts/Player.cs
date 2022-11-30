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
    float dirX;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;

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
        //movement = Input.GetAxis("Horizontal") * speed;

        dirX = Input.acceleration.x * speed;

    }

    private void FixedUpdate()
    {
        playVel = rigidbody.velocity;
        //playVel.x = movement;
        playVel.x = dirX;
        rigidbody.velocity = playVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage();

            /*if (health == 0)
            {
                Destroy(gameObject);
            }*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet")) 
        {
            Destroy(collision.gameObject);

            TakeDamage();

            /*if (health == 0)
            {
                Destroy(gameObject);
            }*/

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

        if (health == 0)
        {
            Destroy(gameObject);

            lose.gameObject.SetActive(true);

            //StartCoroutine(Restart());

            SceneManager.LoadScene("Bunny Jump");
        }

        StartCoroutine(Invincible());
    }

    IEnumerator Restart() 
    {
        yield return new WaitForSeconds(3.0f);
    }


}
