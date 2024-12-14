using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : Enemy
{
    private Rigidbody2D rb;

    private void Start()
    {
        damageOnContact = 1f;
        lifePoints = 20;
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void AttackPattern()
    {
        throw new System.NotImplementedException();
    }

    public override void InitDetection()
    {
        
    }

    protected override void NeutralPattern()
    {
        if(isLeft)
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
        }
        else rb.velocity = new Vector2(1, rb.velocity.y);

        TestTooFar();
    }

    protected void TestTooFar()
    {
        if(!isLeft && transform.position.x>12) transform.position = new Vector2(-10,transform.position.y);
        else if(isLeft && transform.position.x<-12) transform.position = new Vector2(10,transform.position.y);
    }
}
