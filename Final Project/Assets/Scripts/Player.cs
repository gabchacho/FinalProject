using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float movement = 0.0f;
    public float speed = 10.0f;
    Vector2 playVel;
    float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;

        //dirX = Input.acceleration.x * speed;

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
            Destroy(gameObject);
        }
    }


}
