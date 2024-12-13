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
    private void Update()
    {
        if(lifePoints<=0)
        {
            Die();
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("azer");
        if(collision.gameObject.CompareTag("AllyWeapon"))
        {
            WeaponBase wb = collision.gameObject.GetComponent<WeaponBase>();
            LoseHP(wb.GetDamageValue());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Character"))
        {
            CharacterControler c = collision.gameObject.GetComponent<CharacterControler>();
            if (!c.Get_iframes())
            {
                c.LoseHPs(damageOnContact);
            }
        }
    }


}
