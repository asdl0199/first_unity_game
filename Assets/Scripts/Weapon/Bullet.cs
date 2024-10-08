using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isBoost = false;
    public int bulletDamage;
    public float speed;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;

    public bool isLocal = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }
    public void SetDamage(int damage, bool b = false)
    {
        isBoost = b;
        if (b)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        bulletDamage = damage;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (other.gameObject.tag == "Monster")
        {
            int r = Random.Range(-15, 15);
            Em em = other.gameObject.GetComponent<Em>();
            em.GetAtt(bulletDamage + r,isBoost);
            //if (isLocal)
            //{

            //    //GameManager.Instance.Attack(bulletDamage + r);
            //}
        }
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;
       
        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
