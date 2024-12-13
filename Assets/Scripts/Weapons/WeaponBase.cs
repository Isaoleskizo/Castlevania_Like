using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected bool isLeft;
    protected float damage = 1.0f;

    public float GetDamageValue()
    {
        return damage;
    }
    public void SetLeft(bool l)
    {
        isLeft = l;
    }

}
