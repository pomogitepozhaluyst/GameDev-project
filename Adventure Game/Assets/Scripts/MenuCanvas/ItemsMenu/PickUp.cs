using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject buttonE;
    public ItemMenu itemMenu;
    public Item item;
    public Transform parentTransform;
    public LayerMask player;

    // Update is called once per frame
    void Update()
    {
            Collider2D[] players = Physics2D.OverlapCircleAll(parentTransform.position, 1f, player);
        if (players.Length != 0 && Input.GetKeyDown(KeyCode.E))
        {
            buttonE.SetActive(true);
            Destroy(gameObject);
            itemMenu.addItem(item);
        }
        else if (players.Length != 0) {
            buttonE.SetActive(true);

        }
        else
        {
            buttonE.SetActive(false);
        }
    }
}
