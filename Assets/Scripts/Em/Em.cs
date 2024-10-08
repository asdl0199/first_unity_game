using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Em : MonoBehaviour
{
    [SerializeField] bool is_reduce = false;

    [SerializeField] int reduce_level = 0;
    [SerializeField] int hp = 150;

    [SerializeField] private Transform target;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField] private AudioSource aus;


    private void Start()
    {
        //Init(false);
        
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed*0.15f * Time.deltaTime;
            if (direction.x > 0)
                transform.localScale = new Vector3(reduce_level, reduce_level, 1);
            else
                transform.localScale = new Vector3(-reduce_level, reduce_level, 1);


            //Vector3 direction = (target.position - transform.position).normalized;


            //transform.position += direction * moveSpeed*0.1f * Time.deltaTime;

            //Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Æ½»¬Ðý×ª
        }

    }
    public void Init(bool is_re,int s_level = 0)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        aus = gameObject.GetComponent<AudioSource>();
        is_reduce = is_re;
        if (s_level!=0)
        {
            reduce_level = s_level;
            moveSpeed = 5f + 0.5f * s_level;
            hp = 150 + s_level * 35;
        }
        
        if (is_reduce)
        {
            AddT();
        }
        float p = (float)1 / (float)reduce_level;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(p, p);
    }

    public void AddT()
    {
        this.transform.localScale = new Vector3(reduce_level, reduce_level, 1);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }


    public void ReduceT(bool b)
    {
        reduce_level--;
        
        if (reduce_level<=0)
        {
            if (b)
            {
                aus.Play();
                ObjectPool.Instance.PushObject(gameObject);
            }
            else
            {
                reduce_level = 1;
            }
            //Destroy(this.gameObject);
            
            return;
        }
        if (reduce_level>0)
        {
            this.transform.localScale = new Vector3(reduce_level, reduce_level, 1);
        }
        
    }

    public void GetAtt(int dm,bool b)
    {
        if (is_reduce)
        {
            ReduceT(b);
        }
        else
        {
            GetDamage(dm);
           
        }
    }

    void GetDamage(int dm)
    {
        hp -= dm;
        if (hp<=0)
        {
            aus.Play();
            ObjectPool.Instance.PushObject(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().ReduceHP();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().ReduceHP();
        }
    }


}
