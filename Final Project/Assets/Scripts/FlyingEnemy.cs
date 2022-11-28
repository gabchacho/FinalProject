using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float timer = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        //transform.position = Vector3.Lerp(transform.position.y + 2.0f, transform.position.y - 2.0f, 2.0f);

        if (timer <= 0) 
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            timer = 1f;
        }



    }
}
