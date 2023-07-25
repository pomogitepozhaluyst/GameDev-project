using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextValuePointSkills : MonoBehaviour
{
    public Player player;
    public Text text;

    void Update()
    {
        text.text = player.pointSkills.ToString();
    }

}
