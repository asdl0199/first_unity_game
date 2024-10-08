using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Serializable]
    struct WeaponStatus
    {
        public bool isActive;
        public GameObject Weapon;
    }
    [SerializeField] private bool isEnable = false;
    [SerializeField] private WeaponStatus[] weaponStatuses;

    public int w_Index = 0;












}
