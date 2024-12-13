using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDagger : PowerUpBase
{
    protected override void ApplyPowerup(CharacterControler cc)
    {
        cc.SwapWeapon(CharacterControler.SecondaryWeapon.Dagger);
    }
}
