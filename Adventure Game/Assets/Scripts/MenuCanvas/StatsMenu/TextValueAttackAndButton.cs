using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextValueAttackAndButton : MonoBehaviour
{
    public Player player;
    public Text text;
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(attackInc);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.stats.damageMelee.ToString();
    }

    void attackInc()
    {
        if (player.stats.pointSkills != 0)
        {
            player.stats.damageMelee++;
            player.stats.pointSkills--;
        }
    }






}
