using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fireBallTransform;
    public LayerMask enemy;
    public LayerMask other;
    bool destroy = false;
    float timeToDestroy = 1;
    public Animator animator;

    public Rigidbody2D fireBallRB;

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(fireBallTransform.position, 0.4f, enemy);
        Collider2D[] others = Physics2D.OverlapCircleAll(fireBallTransform.position, 0.4f, other);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().TakeDamage(10);
            fireBallRB.velocity = Vector2.zero;
            animator.SetTrigger("isExplosion");
            destroy = true;
        }

        for (int i = 0; i < others.Length; i++)
        {
            others[i].GetComponent<Health>().TakeDamage(10);
            fireBallRB.velocity = Vector2.zero;
            animator.SetTrigger("isExplosion");
            destroy = true;
        }

        if (destroy && timeToDestroy <= 0.0f)
        {
            Destroy(gameObject);
        }
        else if (destroy)
        {
            timeToDestroy -= Time.deltaTime;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(fireBallTransform.position, 0.4f);
    }
}
