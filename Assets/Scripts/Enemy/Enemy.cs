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
    [SerializeField] protected bool isLeft;
    [SerializeField] private int lootPercentage;

    public List<GameObject> potentialLoot;

    // Update is called once per frame
    void Update()
    {
        if (hasDetected) AttackPattern();
        else NeutralPattern();

        if (lifePoints <= 0) Die();
    }
    abstract public void InitDetection();
    abstract protected void AttackPattern();
    abstract protected void NeutralPattern();

    public void SetLeft(bool left)
    {
        isLeft = left;
    }

    public void LoseHP(float hp)
    {
        lifePoints -= hp;
        StartCoroutine(DMGFeedback());
    }

    protected void Die()
    {
        TryToLoot();

        Destroy(gameObject);
    }

    protected virtual void TryToLoot()
    {
        int x = Random.Range(0, potentialLoot.Count+1);
        Debug.Log(x);
        if(Random.Range(lootPercentage,100) == 99) Instantiate(potentialLoot[x], transform.position, Quaternion.identity);
    }


    protected IEnumerator DMGFeedback()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("azer");
        if (collision.gameObject.CompareTag("AllyWeapon"))
        {
            WeaponBase wb = collision.gameObject.GetComponent<WeaponBase>();
            LoseHP(wb.GetDamageValue());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Character"))
        {
            CharacterControler c = collision.gameObject.GetComponent<CharacterControler>();
            if (!c.Get_iframes())
            {
                c.LoseHPs(damageOnContact);
            }
        }
    }
}
