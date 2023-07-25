using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 movement;
    public LayerMask enemy;
    public LayerMask other;

    public float speed;
    public float attackRadius;
    public float seeRadius;
    public bool heSee;
    public string status;
    public Animator animator;
    public Rigidbody2D rb;
    //public Transform pos;

    public bool isInSeeRange;
    public bool isInAttackRange;
    public bool isInOtherCollide;


    public Transform target;

    public Vector2 direction;


    public Transform hitBox;
    private float attackSpeed = 1.0f;
    private float attackBlockTime = 0.0f;


    void Start()
    {
        animator.SetFloat("Speed", speed);
        animator.SetFloat("AttackSpeed", 1);


    }

    // Update is called once per frame
    void Update()
    {



        isInSeeRange = Physics2D.OverlapCircle(transform.position, seeRadius, enemy);
        isInAttackRange = Physics2D.OverlapBox(hitBox.position, new Vector2(0.3f, 0.2f), 0, enemy);
        isInOtherCollide = Physics2D.OverlapBox(hitBox.position, new Vector2(0.3f, 0.2f), 0, other);

        movement = target.position - transform.position;

        if (movement != Vector2.zero)
        {

            hitBox.position = new Vector2(transform.position.x + movement.x / 10, gameObject.transform.position.y + movement.y / 10 - 0.4f);

            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
        }
        if (attackBlockTime >= 0.0f)
        {
            attackBlockTime -= Time.deltaTime;
        }


        if (isInOtherCollide && movement != Vector2.zero)
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
            rb.velocity = movement;
            if (attackBlockTime <= 0)
            {
                AttackOther();
            }
        }
        if (isInSeeRange && !isInAttackRange && !isInOtherCollide && movement != Vector2.zero)
        {
            animator.SetFloat("Speed", 3);
            Move();

        }
        else if(isInAttackRange)
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
            rb.velocity = movement;
            if (attackBlockTime <= 0) {
                Attack();
            }
        }
        else
        {
            movement = Vector2.zero;
            animator.SetFloat("Speed", 0);
            rb.velocity = movement;

        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        attackBlockTime = 1.1f;

        Collider2D[] enemies = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(0.3f, 0.2f), 0, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Player>().TakeDamage(5);
        }
    }

    void AttackOther()
    {
        animator.SetTrigger("Attack");
        attackBlockTime = 1.1f;

        Collider2D[] enemies = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(0.3f, 0.2f), 0, other);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().TakeDamage(5);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(hitBox.position, new Vector2(0.3f, 0.2f));
    }

    void Move()
    {

            rb.velocity = movement * 0.5f * 1.0f;
    }
}
