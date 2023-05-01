using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickupBehaviour : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] Animator animator;
    [SerializeField] MoveBehaviour playerMoveBehaviour;
    private Item currentItem;

    public void DoPickup(Item item)
    {
        //Ajouter l'objet passé à l'inventaire du joueur
        //Jouer l'animation du personnage pour ramasser l'obbjet
        //Bloquer le déplacement du joueur pendant qu'il ramasse l'objet
        if (inventory.isFull())
        {
            Debug.Log("Inventory is full" + item.name);
            return;
        }

        currentItem = item;
        
        animator.SetTrigger("Pickup");
        playerMoveBehaviour.canMove = false;
    }

    public void AddItemToInventory()
    {
        inventory.AddItem(currentItem.itemData);
        Destroy(currentItem.gameObject);

        currentItem = null;
    }

    public void ReEnablePlayerMovement()
    {
        playerMoveBehaviour.canMove = true;
    }
}
