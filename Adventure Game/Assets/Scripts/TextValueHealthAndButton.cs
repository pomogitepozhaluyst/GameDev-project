using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextValueHealthAndButton : MonoBehaviour
{
    public Player player;
    public Text text;
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(healthInc);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.maxHealth.ToString();
    }

    void healthInc()
    {
        if (player.pointSkills != 0)
        {
            player.maxHealth += 1;
            player.pointSkills--;

        }
    }



}
