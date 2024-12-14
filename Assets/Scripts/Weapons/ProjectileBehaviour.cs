using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBehaviour : WeaponBase
{
    //INHERITANCE
    protected float speed = 10.0f; 


    //ABSTRACTION
    protected abstract void Deplacement();


}
