using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy_Fly : Enemy
{
    [SerializeField] private Vector2 pos1;
    [SerializeField] private Vector2 pos2;
    private Vector2 direction;
    [SerializeField] private Vector2 atkPos1;
    [SerializeField] private Vector2 atkPos2;


    private void Awake()
    {
        direction = pos1;
        speed = 2f;
    }

    private void FixedUpdate()
    {
        if(hasDetected) AttackPattern();
        else NeutralPattern();
    }

    private void SwapPos()
    {
        if (direction == pos1) direction = pos2;
        else direction = pos1;
    }

    protected override void NeutralPattern()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        transform.Translate((direction - position).normalized * Time.deltaTime * speed);
        if (position == direction)
        {
            SwapPos();
        }
    }
    override protected void AttackPattern()
    {
        
    }

    override public void InitDetection()
    {
        //placer les marqueurs au niveau du perso
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1, pos2);
    }
}
