using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundCharacter : MonoBehaviour
{
    CharacterControler cc;

    private void Awake()
    {
        cc = transform.parent.GetComponent<CharacterControler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Terrain"))
        {
            cc.ChangeGroundState(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Terrain"))
        {
            cc.ChangeGroundState(false);
        }
    }

}
