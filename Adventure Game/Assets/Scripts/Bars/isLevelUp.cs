
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class isLevelUp : MonoBehaviour
{


    public Player player;
    public GameObject signPointSkills;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.stats.pointSkills == 0)
        {
            signPointSkills.SetActive(false);
        }
        else
        {
            signPointSkills.SetActive(true);
        }
    }
}
