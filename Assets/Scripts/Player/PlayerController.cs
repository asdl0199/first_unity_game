using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private float speed = 6.0f;
    private Vector2 input;
    private Vector2 mousePos;
    private Animator animator;
    private Rigidbody2D rigidbody;
    [SerializeField] private Vector2 playerForward;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = input.normalized * speed;
        //rigidbody.MovePosition((Vector2)this.transform.position+(input.normalized * speed*Time.deltaTime));
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            playerForward = Vector2.left;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            playerForward = Vector2.right;
        }

        if (input != Vector2.zero)
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);
    }

    public Vector2 GetPlayerForward()
    {
        return playerForward;
    }

    public void ReduceHP()
    {
        int r_da = Random.Range(-10, 10);
        HP -= 30 + r_da;
        UIManager.Instance.ChangeHpSlider((float)HP / (float)100);
        if (HP<=0)
        {
            UIManager.Instance.ShowOverPanel();
            Destroy(this.gameObject);
        }
    }


}
