using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("zzz");
        if(collision.transform.CompareTag("Character"))
        { 
            enemy.hasDetected = true;
            enemy.player = collision.GetComponent<CharacterControler>();
            enemy.InitDetection();
        }
    }
}
