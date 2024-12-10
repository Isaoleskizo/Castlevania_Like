using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Variables")]
    private float lifePoints = 10;
    private float lifePointsMax = 10;

    private float manaPoints = 10;
    private float manaPointsMax = 10;


    [Header("Armes")]
    private GameObject whisp;
    private SecondaryWeapon weapon = SecondaryWeapon.Dagger;
    private Vector2 positionWeapon;
    public GameObject prefabProjectile;
    public Transform parentProjectiles;


    [Header("Deplacements")]
    private Rigidbody2D rb2;
    private Vector2 velocity;
    private float movement;
    private float speed = 5.0f;
    private bool _isOnGround=false;
    private bool _iframes = false;
    private bool isLookingLeft = true;




    private void Awake()
    {
        whisp = transform.Find("Whisp").gameObject;
        rb2 = GetComponent<Rigidbody2D>();
        velocity= Vector2.zero;
    }

    public enum SecondaryWeapon
    {
        None,
        Axe,
        Dagger
    }

    private void Update()
    {
        GetDirection();

        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround) 
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseSecondaryWeapon();
        }
        rb2.velocity = velocity;
    }


    private void UseSecondaryWeapon()
    {
        switch(weapon)
        {
            case SecondaryWeapon.Dagger:
                UseDagger();
                break;
            case SecondaryWeapon.Axe:
                Debug.Log("pas implémenté");
                break;
            case SecondaryWeapon.None:
                Debug.Log("None");
                break;
            default:
                Debug.Log("bug");
                break;
        }
    }
    private void UseDagger()
    {
        GameObject dagger;
        int value = 1;
        Debug.Log("Dague");
        if (isLookingLeft) value = -1;
        else value = 1;
        dagger = Instantiate(prefabProjectile, transform.position + new Vector3(value*0.5f, 0), Quaternion.Euler(0, 0, 90), parentProjectiles);
        dagger.GetComponent<ProjectileBehaviour>().isLeft = isLookingLeft;
    }
    private void GetDirection()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0) isLookingLeft = false;
        else if (movement < 0) isLookingLeft = true;

        if (isLookingLeft) positionWeapon = new Vector2(-1.5f, 0.25f);
        else positionWeapon = new Vector2(1.5f, 0.25f);


        velocity = new Vector2(movement * speed, rb2.velocity.y);
    }
    private void Attack()
    {
        whisp.transform.localPosition = positionWeapon;
        whisp.SetActive(true);
        StartCoroutine(ActiveTimeWeapon());
    }
    IEnumerator ActiveTimeWeapon()
    {
        yield return new WaitForSeconds(0.25f);
        whisp.SetActive(false);
    }
    private void Jump()
    {
        velocity.y = 7f; ;
    }
    public void GainHPs(float life)
    {
        lifePoints += life;
        if(lifePoints>lifePointsMax) lifePoints=lifePointsMax;
    }
    public void LoseHPs(float life)
    {
        lifePoints -= life;
        if(lifePoints < 0) lifePoints = 0;
    }
    public void GainMana(float mana)
    {
        manaPoints += mana;
        if(manaPoints > manaPointsMax) manaPoints = manaPointsMax;
    }
    public void LoseMana(float mana)
    {
        manaPoints -= mana;
        if(manaPoints < 0) manaPoints = 0;
    }
    public void DegatsSubits(bool left)
    {
        _iframes = true;
        StartCoroutine(Cooldown_iFrames());

        if(left)
        {
            velocity += Vector2.left;
        }
        else velocity += Vector2.right;

    }
    IEnumerator Cooldown_iFrames()
    {
        yield return new WaitForSeconds(0.25f);
        _iframes = false;
    }
    public void SwapWeapon(SecondaryWeapon x)
    {
        weapon = x;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Terrain"))
        {
            _isOnGround= true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Terrain"))
        {
            _isOnGround = false;
        }
    }
}
