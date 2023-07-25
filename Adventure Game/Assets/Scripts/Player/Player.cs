using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public StatsData stats;

    public float fullSpeed = 50.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public string direction = "down";
    public float baseAnimatorSpeed = 1.0f;
    public Transform hitBox;






    Vector2 movement;

  

    void Start()
    {


    }

    public void TakeDamage(int damage)
    {
        stats.TakeDamage(damage);
    }

    void RecoverHealth(int recover)
    {
        stats.RecoverHealth(recover);

    }

    // Update is called once per frame
    void Update()
    {





        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            hitBox.position = new Vector2(transform.position.x + movement.x /10, gameObject.transform.position.y + movement.y /10-0.2f);

            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
        }
        animator.SetFloat("Speed", Mathf.Clamp(movement.magnitude, 0.0f, 1.0f));

        Move();

        if (Input.GetKeyUp(KeyCode.R))
        {
            RecoverHealth(1);
        }




    }





    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            rb.velocity = movement * fullSpeed * 1.0f;
        }
        else {
            rb.velocity = movement * stats.baseSpeed * 1.0f;
        }
    }
}
