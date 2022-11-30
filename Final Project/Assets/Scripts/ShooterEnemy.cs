using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public Player player;
    public GameObject bulletPrefab;
    public float range = 20, distToPlayer;
    Vector3 currRot;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (null == player)
        {
            player = FindObjectOfType<Player>();
        }

        currRot.y = 180;
        transform.localEulerAngles = currRot;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer <= range) 
        {
            if (player.transform.position.x > transform.position.x && transform.localEulerAngles.y > 0
                || player.transform.position.x < transform.position.x && transform.localEulerAngles.y < 0) 
            {
                Flip();
            }


            //shoot
        }


    }

    void Flip() 
    {
        currRot.y *= -1;
        transform.localEulerAngles = currRot;
    }

}

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    //public bool facingLeft = true;
    public float timer = 2.0f;
    public GameObject bulletPrefab;
    public List<Transform> firePoints;
    public Player player;
  
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        if (null == player)
        {
            player = FindObjectOfType<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) 
        {
            foreach (Transform t in firePoints) 
            {
                //if (transform.position.x > player.transform.position.x)
                //{
                    Vector3 currRot = transform.localEulerAngles;
                    currRot.y += 180;
                    transform.localEulerAngles = currRot;
                //}

                Instantiate(bulletPrefab, t.position, t.rotation);

            }

            timer = 2.0f;
        }



    }
}

 
 */