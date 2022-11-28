using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    bool onGround = false;
    bool facingRight = true;
    Vector3 start, end;
    Vector2 vel;

    // Start is called before the first frame update
    protected override void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        //rigid = GetComponent<Rigidbody2D>();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //start 
        //take enemy position + the facing direction by some distance... start point
        if (facingRight)
        {
            start = base.transform.position + Vector3.right;
        }
        else
        {
            start = base.transform.position + Vector3.left;
        }

        //straight down... start and the down 
        end = start + Vector3.down;

        if (!onGround && !Physics2D.Linecast(start, end))
        {
            //onGround = Physics2D.Linecast(start, end);

            Vector3 currRot = base.transform.localEulerAngles;
            currRot.y += 180;
            base.transform.localEulerAngles = currRot;

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

        vel = base.rigid.velocity;
        vel.x = Vector2.right.x * base.m_forwardSpeed;
        base.rigid.velocity = vel;

    }


    IEnumerator Wait()
    {
        onGround = true;

        yield return new WaitForSeconds(0.3f);

        onGround = false;
    }

}
