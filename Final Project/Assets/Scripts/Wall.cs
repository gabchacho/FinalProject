using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Transform m_target;
    Rigidbody2D rb;
    Vector3 m_velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = m_target.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_velocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       float speed = m_velocity.magnitude;

       var direction = Vector3.Reflect(m_velocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}
