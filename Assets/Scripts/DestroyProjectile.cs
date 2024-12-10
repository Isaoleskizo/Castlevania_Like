using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Character"))
        {
            collision.GetComponent<CharacterControler>().LoseHPs(1);
            Destroy(gameObject);
        }
    }
}
