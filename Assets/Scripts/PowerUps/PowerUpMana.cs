using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMana : PowerUpBase
{
    protected float mana = 10f;
    override protected void ApplyPowerup(CharacterControler cc)
    {
        Debug.Log("+" + mana + "mana !");
        cc.GainMana(mana);
    }
}
