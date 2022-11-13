using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float movement = 0.0f;
    public float speed = 10.0f;
    Vector2 playVel;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        playVel = rigidbody.velocity;
        playVel.x = movement;
        rigidbody.velocity = playVel;
    }


}
