using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public float m_forwardSpeed = 2.2f;
    protected Rigidbody2D rigid;

    public AudioSource slimeDead;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            health -= 1;

            if (health == 0) 
            {
                //slimeDead.Play();

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

    }

}
