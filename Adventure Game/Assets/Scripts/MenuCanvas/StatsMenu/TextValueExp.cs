using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextValueExp : MonoBehaviour
{
    public Player player;
    public Text text;

    void Update()
    {
        text.text = player.stats.currentExp.ToString()+'/'+ player.stats.needToNextLevelExp.ToString();
    }


}
