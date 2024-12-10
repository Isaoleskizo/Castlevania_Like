using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public CharacterControler player;
    protected float lifePoints;
    protected float speed;
    public bool hasDetected;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasDetected) AttackPattern();
    }

    abstract public void InitDetection();
    abstract protected void AttackPattern();
    abstract protected void NeutralPattern();
}
