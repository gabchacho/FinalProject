using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float jumpForce = 10.0f;
    Vector2 velocity;
    Rigidbody2D rigid;
    //public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>()) 
        {
            if (collision.relativeVelocity.y <= 0.0f)
            {
                rigid = collision.gameObject.GetComponent<Rigidbody2D>();

                velocity = rigid.velocity;
                velocity.y = jumpForce;
                rigid.velocity = velocity;

                //jumpSound.Play();
                collision.gameObject.GetComponent<Player>().jumpSound.Play();
            }
        }
    }


}
