using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMana : PowerUpBase
{
    protected float mana = 1.0f;
    override protected void ApplyPowerup(CharacterControler cc)
    {
        Debug.Log("+" + mana + "mana !");
        cc.GainMana(mana);
    }
}
