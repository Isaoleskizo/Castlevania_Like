using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHP : PowerUpBase
{
    protected float life = 1.0f;
    override protected void ApplyPowerup(CharacterControler cc)
    {
        Debug.Log("+" + life + "HPs !");
        cc.GainHPs(life);
    }
}
