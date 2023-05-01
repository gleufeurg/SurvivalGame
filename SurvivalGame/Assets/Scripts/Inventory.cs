using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemData> content = new List<ItemData>();
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform inventorySlotsParent;
    [SerializeField] const int Inventory_Size = 24;


    private void Start()
    {
        //Actualise l'inventaire dès le début si jamais il y a des objets déjà présents dans l'inventaire au début du jeu
        RefreshContent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }

    public void AddItem(ItemData item)
    {
        //Ajoute l'item renseigné dans l'inventaire
        //Actualise l'inventaire avec les nouvelles informations
        content.Add(item);
        RefreshContent();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void RefreshContent()
    {
        //Boucle sur chacun des éléments de l'inventaire (la liste)
        //Set l'item data du Script Slot conformément au Scriptable Object du prefab qui se trouve dans ce slot de l'inventaire
        //Set le visuel à afficher conformément au visual qui se trouve dans le Scriptable Object du prefab qui se trouve dans ce slot de l'inventaire
        for (int i = 0; i < content.Count; i++)
        {
            Slot currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.item = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }
    }

    public bool isFull()
    {
        //Return true si l'inventaire est plein
        //Pratique si l'on veut savoir lorsque celui-ci est plein
        return Inventory_Size == content.Count;
    }
}
