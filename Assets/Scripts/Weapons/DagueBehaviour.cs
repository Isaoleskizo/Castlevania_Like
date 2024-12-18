using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagueBehaviour : ProjectileBehaviour
{

    //INHERITANCE
    private void Start()
    {
        damage = 1.0f;
        speed = 10.0f;
    }
    private void FixedUpdate()
    {
        Deplacement();
        TryDeleteDague();
    }

    protected override void Deplacement()
    {
        if (isLeft) transform.localPosition += new Vector3(-1f, 0f) * Time.deltaTime * speed;
        else transform.localPosition += new Vector3(1f, 0f) * Time.deltaTime * speed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Terrain")) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("pingcollision");
    }

    private void TryDeleteDague()
    {
        if (transform.position.x > 25) Destroy(gameObject);
    }
}
