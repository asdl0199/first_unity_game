using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class WeaponBase : MonoBehaviour
{
    [SerializeField] bool isMain = false;
    [SerializeField] bool isEnable = false;
    [SerializeField] bool isBoost = false;
    [SerializeField] private float interval;
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private int damage;
    [SerializeField] private int capacity;
    [SerializeField] private int now_cap;
    [SerializeField] private float c_interval;
    [SerializeField]private float c_t;
    protected Transform firePos;
    protected Vector2 mousePos;
    [SerializeField] protected Vector2 direction;
    protected float timer;
    protected float flipY;
    [SerializeField] private AudioSource aus;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        flipY = transform.localScale.y;
        firePos = transform.Find("firepoinnt");
    }

    protected virtual void AddSpeed()
    {
        interval = interval - interval * 0.1f;
    }

    protected virtual void AddDamage()
    {
        damage = (int)(damage + damage * 0.25f);
    }
    protected virtual void AddCapacity()
    {
        capacity += 10;
    }

    // Update is called once per frame


    public void BoostWeapon()
    {
        isBoost = true;
        c_t = 0;
        now_cap = capacity;
    }

    public void SBoost()
    {
        isBoost = false;
    }


    protected virtual void Update()
    {
        if (isEnable)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            if (mousePos.x < transform.position.x)//L
                transform.localScale = new Vector3(flipY, -flipY, 1);
            else
                transform.localScale = new Vector3(flipY, flipY, 1);

            Shoot();
        }
        if (c_t!=0)
        {
            c_t -= Time.deltaTime;
            float a = (float)c_t / (float)c_interval;
            //Debug.Log(a);
            if (isMain)
            {
                UIManager.Instance.ChangeReloadSlider(a);
            }
            if (c_t<=0)
            {
                c_t = 0;
                now_cap = capacity;
                if (isMain)
                {
                    UIManager.Instance.ChangeAmmoSlider(1);
                }
            }
        }
    }
    public void EnableScript(bool b)
    {
        isEnable = b;
    }
    public Vector2 GetDirection()
    {
        return direction;
    }

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }

    public Vector2 GetFirePoint()
    {
        return firePos.position;
    }

    protected virtual void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }
        if (timer == 0)
        {
            timer = interval;
            if (now_cap <= 0)
            {
                SBoost();
                if (c_t <= 0)
                {
                    c_t = c_interval;
                }
                if (isBoost)
                {
                    SBoost();
                }
                return;
            }

            Fire();
        }
        //if (Input.GetButton("Fire1"))
        //{
        //    if (timer == 0)
        //    {
        //        timer = interval;
        //        if (now_cap<=0)
        //        {
        //            if (c_t <= 0)
        //            {
        //                c_t = c_interval;
        //                //Debug.Log("»»µ¯");
        //            }
        //            return;
        //        }

        //        Fire();
        //    }
        //}
    }

    protected virtual void ChangeAm()
    {

    }

    protected virtual void Fire()
    {
        //animator.SetTrigger("Shoot");

        
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);

        bullet.transform.position = firePos.position;

        float angel = Random.Range(-5f, 5f);
        Vector2 bulletS = Quaternion.AngleAxis(angel, Vector3.forward) * direction;
        //GameManager.Instance.Shoot(bulletS);
        Bullet t = bullet.GetComponent<Bullet>();
        t.SetSpeed(bulletS);
        t.SetDamage(damage,isBoost);
        now_cap--;
        if (isMain)
        {
            float pe = (float)now_cap / (float)capacity;
            UIManager.Instance.ChangeAmmoSlider(pe);
        }
        aus.Play();
        //t.isLocal = true;
    }

    //protected virtual void Fire()
    //{
    //    //animator.SetTrigger("Shoot");

    //    // GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
    //    RaycastHit2D hit2D = Physics2D.Raycast(firePos.position, direction, 30);
    //    //Debug.Log(direction);
    //    GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
    //    LineRenderer tracer = bullet.GetComponent<LineRenderer>();
    //    tracer.SetPosition(0, firePos.position);
    //    tracer.SetPosition(1, hit2D.point);
    //    //bullet.transform.position = firePos.position;

    //    //float angel = Random.Range(-5f, 5f);
    //    //Vector2 bulletS = Quaternion.AngleAxis(angel, Vector3.forward) * direction;
    //    //GameManager.Instance.Shoot(bulletS);
    //    Bullet t = bullet.GetComponent<Bullet>();
    //    //t.SetSpeed(bulletS);
    //    //t.SetDamage(damage);
    //    now_cap--;
    //    if (isMain)
    //    {
    //        float pe = (float)now_cap / (float)capacity;
    //        UIManager.Instance.ChangeAmmoSlider(pe);
    //    }

    //    //t.isLocal = true;
    //}



}
