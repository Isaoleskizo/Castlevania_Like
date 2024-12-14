using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAxe : PowerUpBase
{    
    //INHERITANCE
    protected override void ApplyPowerup(CharacterControler cc)
    {
        cc.SwapWeapon(CharacterControler.SecondaryWeapon.Axe);
    }
}
