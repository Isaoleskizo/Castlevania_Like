using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBehaviour : MonoBehaviour
{
    protected bool isAllyProjectile;
    protected bool isLeft;
    protected float speed = 10.0f;

    protected abstract void Deplacement();

    public void SetLeft(bool l)
    {
        isLeft = l;
    }

}
