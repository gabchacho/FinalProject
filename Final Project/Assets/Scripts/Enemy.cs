using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float m_forwardSpeed = 1.0f;
    //SpriteRenderer sprite;
    Rigidbody2D rigid;
    bool onGround = false;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      

        //transform.position += Vector3.right.x * m_forwardSpeed * Time.deltaTime;

        //start 
        //take enemy position + the facing direction by some distance... start point
        Vector3 start = transform.position + Vector3.right;

        //straight down... start and the down 
        Vector3 end = start + Vector3.down;

        Debug.DrawLine(start, end);

        //RaycastHit2D rc = Physics2D.Linecast(start, end);

        if (!onGround && !Physics2D.Linecast(start, end)) 
        {
            //onGround = Physics2D.Linecast(start, end);

            Vector3 currRot = transform.localEulerAngles;
            currRot.y += 180;
            transform.localEulerAngles = currRot;
            m_forwardSpeed *= -1;
            StartCoroutine(Wait());
        }

        vel = rigid.velocity;
        vel.x = Vector2.right.x * m_forwardSpeed;
        rigid.velocity = vel;

    }


    IEnumerator Wait() 
    {
        onGround = true;

        yield return new WaitForSeconds(1);

        onGround = false;
    }







}
