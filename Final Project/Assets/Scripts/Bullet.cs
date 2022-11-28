using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    public GameObject m_explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Explode();
 
    }


    void Explode()
    {
        if (null != m_explosion)
        {
            GameObject explode = Instantiate(m_explosion);
            explode.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

}
