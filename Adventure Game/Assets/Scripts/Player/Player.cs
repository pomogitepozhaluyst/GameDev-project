using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth = 1;
    public int level = 1;
    public int damageMelee = 1;
    public int damageDistant = 1;
    public float fullSpeed = 50.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public string direction = "down";
    public float baseSpeed = 3.0f;
    public float baseAnimatorSpeed = 1.0f;
    public Transform hitBox;

    public int currentExp = 0;
    public int needToNextLevelExp = 10;

    public int pointSkills = 0;


    public GameObject signPointSkills;


    Vector2 movement;

    public HealthBar healthBar;
    public ExpBar exphBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);

        exphBar.SetMaxExp(needToNextLevelExp);
        exphBar.SetExp(currentExp);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void RecoverHealth(int recover)
    {
        currentHealth += recover;

        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (pointSkills == 0)
        {
            signPointSkills.SetActive(false);
        }
        else
        {
            signPointSkills.SetActive(true);
        }

        exphBar.SetExp(currentExp);

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

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


        while(currentExp >= needToNextLevelExp)
        {
            currentExp -= needToNextLevelExp;
            pointSkills++;
            needToNextLevelExp *= 2;
            level++;
            exphBar.SetMaxExp(needToNextLevelExp);

        }

    }





    void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            rb.velocity = movement * fullSpeed * 1.0f;
        }
        else {
            rb.velocity = movement * baseSpeed * 1.0f;
        }
    }
}
