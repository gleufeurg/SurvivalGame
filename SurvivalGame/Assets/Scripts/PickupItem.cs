using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] float pickupRange = 2.6f;
    [SerializeField] KeyCode key;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject pickupText;

    public PickupBehaviour playerPickupBehaviour;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, layerMask))
        {
            if (hit.transform.CompareTag("Item"))
            {
                pickupText.SetActive(true);

                if(Input.GetKeyDown(key))
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
        else
        {
            pickupText.SetActive(false);
        }
    }
}
