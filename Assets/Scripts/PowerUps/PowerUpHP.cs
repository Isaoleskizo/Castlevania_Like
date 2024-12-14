using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHP : PowerUpBase
{
    //INHERITANCE
    protected float life = 1.0f;
    //POLYMORPHISM
    override protected void ApplyPowerup(CharacterControler cc)
    {
        Debug.Log("+" + life + "HPs !");
        cc.GainHPs(life);
    }
}
