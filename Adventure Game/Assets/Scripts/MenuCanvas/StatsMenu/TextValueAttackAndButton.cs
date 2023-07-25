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
        text.text = player.damageMelee.ToString();
    }

    void attackInc()
    {
        if (player.pointSkills != 0)
        {
            player.damageMelee++;
            player.pointSkills--;
        }
    }






}
