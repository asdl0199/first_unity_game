using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon_Box : MonoBehaviour
{
    [SerializeField] private AudioSource aus;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponentInChildren<Weapon_Rifle>().BoostWeapon();
            aus.Play();
            Destroy(this.gameObject);
        }
    }
}
