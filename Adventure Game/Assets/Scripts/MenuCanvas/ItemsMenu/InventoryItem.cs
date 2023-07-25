using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Image image;
    public Player player;

    public Item item;
    public Transform parentAfterDrag;

    // Start is called before the first frame update

    public void InitialiseItem(Item newItem, Player player1)
    {
        player = player1;
        item = newItem;
        image.sprite = newItem.image;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Destroy(gameObject);

            useItem();
        }
    }


    void useItem()
    {
        if(item.type == 0)
        {
            player.stats.currentHealth += 10;
            if (player.stats.currentHealth < player.stats.maxHealth)
            {
                player.stats.currentHealth = player.stats.maxHealth;
            }
        }
    }

}
