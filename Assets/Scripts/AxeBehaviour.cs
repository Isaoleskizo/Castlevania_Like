using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxeBehaviour : ProjectileBehaviour
{
    private float initialXWhenShoot;
    private float initialYWhenShoot;

    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        isAllyProjectile = true;
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
        //calcule la position actuelle de X par rapport à la fonction
        float currentX = transform.position.x - initialXWhenShoot;
        float currentY = transform.position.y - initialYWhenShoot;
        //verifie le sens dans lequel la fonction s'applique
        int direction = isLeft ? -1 : 1;
        //fonction f(x) = 1/2 * x² + 3x
        float objectiveY = -0.5f * currentX * (currentX - (direction * 6));

        //Je ne comprends pas "objectiveY - transform.position.y + initialYWhenShoot 
        transform.Translate(new Vector3(speed * direction * Time.deltaTime, objectiveY - currentY));

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
