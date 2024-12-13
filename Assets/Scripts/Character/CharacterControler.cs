using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float lifePoints = 7;
    private float lifePointsMax = 10;

    [SerializeField] private float manaPoints = 10;
    private float manaPointsMax = 10;


    [Header("Armes")]
    private GameObject whisp;
    public SecondaryWeapon weapon = SecondaryWeapon.None;
    private Vector2 positionWeapon;
    public GameObject prefabDagger;
    public GameObject prefabAxe;
    public Transform parentProjectiles;


    [Header("Deplacements")]
    private Rigidbody2D rb2;
    private Vector2 velocity;
    private float movement;
    private float speed = 5.0f;
    private bool _isOnGround=false;
    private bool isLookingLeft = true;
    private bool weaponCooldown = false;

    [Header("Damage")]
    private bool _iframes = false;
    public GameObject shield;



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
        if(!weaponCooldown)
        { 
             switch(weapon)
            {
                case SecondaryWeapon.Dagger:
                    UseWeapon(prefabDagger, new Vector3(0,0,90));
                    break;
                case SecondaryWeapon.Axe:
                    UseWeapon(prefabAxe);
                    break;
                case SecondaryWeapon.None:
                    Debug.Log("None");
                    break;
                default:
                    Debug.Log("bug");
                    break;
            }
            StartCoroutine(CooldownWeapon(0.5f));
        }
    }
    IEnumerator CooldownWeapon(float time)
    {
        weaponCooldown = true;
        yield return new WaitForSeconds(time);
        weaponCooldown = false;
    }
    private void UseWeapon(GameObject prefab)
    {
        UseWeapon(prefab, Vector3.zero);
    }
    private void UseWeapon(GameObject prefab, Vector3 rotation)
    {
        int value = isLookingLeft? -1:1;
        GameObject axe = Instantiate(prefab, new Vector3(transform.position.x + value*0.5f, transform.position.y), Quaternion.Euler(rotation), parentProjectiles);
        axe.GetComponent<ProjectileBehaviour>().SetLeft(isLookingLeft);
    }

    public bool Get_iframes()
    {
        return _iframes;
    }

    public void ChangeGroundState(bool b)
    {
        _isOnGround = b;
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
        whisp.GetComponent<WeaponBase>().SetLeft(isLookingLeft);
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

    public void LoseHPs(float life)
    {
        lifePoints -= life;
        if (lifePoints < 0) lifePoints = 0;
        StartCoroutine(Cooldown_iFrames());
    }





    public void GainHPs(float life)
    {
        lifePoints += life;
        if(lifePoints>lifePointsMax) lifePoints=lifePointsMax;
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
    IEnumerator Cooldown_iFrames()
    {
        _iframes = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _iframes = false;
        shield.SetActive(false);
    }

    public void SwapWeapon(SecondaryWeapon x)
    {
        weapon = x;
    }


}
