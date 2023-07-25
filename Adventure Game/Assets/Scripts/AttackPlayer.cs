using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{


    public Transform hitBox;
    private float attackSpeed = 1.0f;
    private float attackBlockTime = 0.0f;
    public Animator animator;
    public LayerMask enemy;
    public LayerMask other;


    public GameObject fireBallPrefab;
    public Rigidbody2D playerRB;

    Vector2 directionDistanceAttack;





    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("AttackSpeed", attackSpeed);
        directionDistanceAttack.x = 0.0f;
        directionDistanceAttack.y = 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        if (attackBlockTime >= 0.0f)
        {
            attackBlockTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale > 0.0f)
        {
            AttackSword();
        }


        if (playerRB.velocity.x != 0.0f || playerRB.velocity.y != 0.0f)
        {
            directionDistanceAttack = playerRB.velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0.0f)
        {
            AttackFireBall();
        }

    }


    void AttackFireBall()
    {
        GameObject fireBall = Instantiate(fireBallPrefab, hitBox.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody2D>().velocity = directionDistanceAttack*3;
    }



    void AttackSword()
    {
        animator.SetTrigger("Attack");
        attackBlockTime = 1.1f;

        Collider2D[] enemies = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(0.5f, 1f), 0, enemy);
        Collider2D[] others = Physics2D.OverlapBoxAll(hitBox.position, new Vector2(0.5f, 1f), 0, other);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().TakeDamage(5);
        }

        for (int i = 0; i < others.Length; i++)
        {
            others[i].GetComponent<Health>().TakeDamage(5);
        }
    }
}
