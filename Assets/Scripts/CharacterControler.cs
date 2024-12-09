using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private Rigidbody2D rb2;
    private float direction;
    public float speed = 1f;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector2.zero;
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        velocity += Vector2.right * direction * speed;


        rb2.velocity += velocity;
        if (rb2.velocity.x > 5f) rb2.velocity = new Vector2(5f, transform.position.y);
        else if (rb2.velocity.x < -5f) rb2.velocity = new Vector2(-5f, transform.position.y);


    }
}
