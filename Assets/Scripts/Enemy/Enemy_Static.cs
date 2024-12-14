using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Static : Enemy
{
    private void Start()
    {
        damageOnContact = 2;
        lifePoints = 10;
    }
    override public void InitDetection()
    {

    }
    override protected void AttackPattern()
    {

    }
    override protected void NeutralPattern()
    {

    }

}
