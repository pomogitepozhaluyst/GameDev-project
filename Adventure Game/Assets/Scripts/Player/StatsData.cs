using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsData : MonoBehaviour
{

    public int maxHealth = 1;
    public int currentHealth = 1;
    public int damageMelee = 1;
    public int damageDistant = 1;
    public int level = 1;
    public float baseSpeed = 3.0f;

    public int currentExp = 0;
    public int needToNextLevelExp = 10;

    public int pointSkills = 0;


    public GameObject signPointSkills;
    public HealthBar healthBar;
    public ExpBar exphBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(maxHealth);

        exphBar.SetMaxExp(needToNextLevelExp);
        exphBar.SetExp(currentExp);
    }

    // Update is called once per frame
    void Update()
    {
        exphBar.SetExp(currentExp);

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

        if (pointSkills == 0)
        {
            signPointSkills.SetActive(false);
        }
        else
        {
            signPointSkills.SetActive(true);
        }

        while (currentExp >= needToNextLevelExp)
        {
            currentExp -= needToNextLevelExp;
            pointSkills++;
            needToNextLevelExp *= 2;
            level++;
            exphBar.SetMaxExp(needToNextLevelExp);

        }
    }




    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void RecoverHealth(int recover)
    {
        currentHealth += recover;

        healthBar.SetHealth(currentHealth);
    }



}
