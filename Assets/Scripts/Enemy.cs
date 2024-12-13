using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected CharacterControler cc;
    protected float lifePoints;
    protected float damageOnContact;
    protected float speed;
    public bool hasDetected;



    // Update is called once per frame
    void Update()
    {
        if (hasDetected) AttackPattern();
        else NeutralPattern();
    }
    abstract public void InitDetection();
    abstract protected void AttackPattern();
    abstract protected void NeutralPattern();

    public void LoseHP(float hp)
    {
        lifePoints -= hp;
        StartCoroutine(DMGFeedback());
    }

    protected void Die()
    {
        //Chance de Loot

        Destroy(gameObject);
    }

    protected IEnumerator DMGFeedback()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
