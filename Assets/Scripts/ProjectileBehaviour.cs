using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public bool isLeft;
    private float speed = 10.0f;
    private void Update()
    {
        if(isLeft) transform.localPosition += new Vector3(-1f, 0f) * Time.deltaTime * speed;
        else transform.localPosition += new Vector3(1f, 0f)*Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Character"))
        {
            collision.GetComponent<CharacterControler>().LoseHPs(1);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Terrain")) Destroy(gameObject);
    }
}
