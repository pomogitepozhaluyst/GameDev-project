using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedSave : MonoBehaviour
{
    public GameObject buttonE;
    public LayerMask player;
    public Transform parentTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Collider2D[] players = Physics2D.OverlapBoxAll(parentTransform.position, new Vector2(4f, 4f), 0f, player);
        if (players.Length != 0 && Input.GetKeyDown(KeyCode.E))
        {
            buttonE.SetActive(true);
        }
        else if (players.Length != 0)
        {
            buttonE.SetActive(true);

        }
        else
        {
            buttonE.SetActive(false);
        }
    }
}
