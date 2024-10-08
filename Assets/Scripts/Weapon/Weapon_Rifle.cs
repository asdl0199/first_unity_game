using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Rifle : WeaponBase
{


    public void AddS()
    {
        base.AddSpeed();
    }
    public void AddD()
    {
        base.AddDamage();
    }
    public void AddC()
    {
        base.AddCapacity();
    }

}
