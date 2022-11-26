using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

    public float m_forwardSpeed = 0.2f;
    //SpriteRenderer sprite;
    Rigidbody2D rigid;
    bool onGround = false;
    Vector2 vel;
    bool facingRight = true;
    Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //start 
        //take enemy position + the facing direction by some distance... start point
        if (facingRight)
        {
            start = transform.position + Vector3.right;
        } else 
        {
            start = transform.position + Vector3.left;
        }


        //straight down... start and the down 
        end = start + Vector3.down;

        //Debug.DrawLine(start, end);

        //RaycastHit2D rc = Physics2D.Linecast(start, end);

        if (!onGround && !Physics2D.Linecast(start, end)) 
        {
            //onGround = Physics2D.Linecast(start, end);

            Vector3 currRot = transform.localEulerAngles;
            currRot.y += 180;
            transform.localEulerAngles = currRot;

            if (facingRight)
            {
                facingRight = false;
            }
            else 
            {
                facingRight = true;
            }

            m_forwardSpeed *= -1f;
            StartCoroutine(Wait());
        }

        vel = rigid.velocity;
        vel.x = Vector2.right.x * m_forwardSpeed;
        rigid.velocity = vel;

    }


    IEnumerator Wait() 
    {
        onGround = true;

        yield return new WaitForSeconds(0.3f);

        onGround = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }





}
