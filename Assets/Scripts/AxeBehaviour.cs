using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxeBehaviour : ProjectileBehaviour
{
    private float initialXWhenShoot;
    private float initialYWhenShoot;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        initialXWhenShoot = transform.position.x;
        initialYWhenShoot = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Deplacement();
        TryDeleteAxe();
    }

    protected override void Deplacement()
    {
        float currentX = transform.position.x - initialXWhenShoot;
        int direction = isLeft ? -1 : 1;
        float objectiveY = -0.5f * currentX * (currentX - (direction * 6));
        transform.Translate(new Vector3(speed * direction * Time.deltaTime, objectiveY - transform.position.y + initialYWhenShoot));

    }


    private void TryDeleteAxe()
    {
        if (transform.position.y < -5) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("salut");
    }
}
