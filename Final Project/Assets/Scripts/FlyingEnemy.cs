using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    //public bool facingLeft = true;
    public float timer = 2.0f;
    public GameObject bulletPrefab;
    public List<Transform> firePoints;
    //public Transform firePoint_0;
    //public Transform firePoint_1;
    //public Transform firePoint_2;

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
            foreach (Transform t in firePoints) 
            {
                Instantiate(bulletPrefab, t.position, t.rotation);
            }

            /*Instantiate(bulletPrefab, firePoint_0.position, firePoint_0.rotation);
            Instantiate(bulletPrefab, firePoint_1.position, firePoint_1.rotation);
            Instantiate(bulletPrefab, firePoint_2.position, firePoint_2.rotation);
            */

            timer = 2.0f;
        }



    }
}
