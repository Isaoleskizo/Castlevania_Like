using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{

    protected abstract void ApplyPowerup(CharacterControler cc);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bite");
        if(collision.transform.CompareTag("Character"))
        {
            CharacterControler cc = collision.transform.GetComponent<CharacterControler>();
            ApplyPowerup(cc);
            Destroy(gameObject);
        }
    }
}
