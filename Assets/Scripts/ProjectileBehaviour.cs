using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    protected bool isLeft;
    protected float speed = 10.0f;
    private void FixedUpdate()
    {
        Deplacement();
    }

    protected virtual void Deplacement()
    {
        if (isLeft) transform.localPosition += new Vector3(-1f, 0f) * Time.deltaTime * speed;
        else transform.localPosition += new Vector3(1f, 0f) * Time.deltaTime * speed;
    }

    public void SetLeft(bool l)
    {
        isLeft = l;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Terrain")) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("pingcollision");
    }
}
