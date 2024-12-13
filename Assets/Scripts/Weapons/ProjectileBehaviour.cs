using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class ProjectileBehaviour : WeaponBase
{
    protected float speed = 10.0f; 


    protected abstract void Deplacement();


}
