using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMana : PowerUpBase
{
    //INHERITANCE
    protected float mana = 10f;
    //POLYMORPHISM
    override protected void ApplyPowerup(CharacterControler cc)
    {
        Debug.Log("+" + mana + "mana !");
        cc.GainMana(mana);
    }
}
