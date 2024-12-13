using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{

    protected abstract void ApplyPowerup(CharacterControler cc);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Character"))
        {
            Debug.Log(collision);
            CharacterControler cc = collision.transform.GetComponent<CharacterControler>();
            ApplyPowerup(cc);
            Destroy(gameObject);
        }
    }
}
