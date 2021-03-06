using System.Collections.Generic;
using UnityEngine;

public class UpgradableModule : MonoBehaviour
{
    [Tooltip("What object is spawned when this building is upgraded")]
    [SerializeField] private GameObject UpgradedObject;

    [Tooltip("The item list to use")]
    [SerializeField] private ItemsList list;

    [Tooltip("The resources needed to upgrade this building")]
    [SerializeField] private List<ToSearchItem> NeededItems = new List<ToSearchItem>();

    [Tooltip("If this building is destroyed when upgraded. ")]
    [SerializeField] private bool IsReusable = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //function that tries to upgrade the current building with the materials in the inventory
    public void TryUpgrade(Inventory inventory)
    {
        //check the inventory equals the needed items and remove them from the inventory
        if(inventory.CheckAndRemove(list.items.GetItemsSlots(NeededItems)))
        {
            //upgrade the building
            //FIRST, spawn the upgraded version on the same position
            GameObject.Instantiate(UpgradedObject, transform.position, Quaternion.identity);

            //Debug message on succesful upgrade
            Debug.Log("Upgrade succesful !");

            //SECOND, destroy myself if not reusable
            if(!IsReusable)
            {
                Destroy(gameObject);
            }
        }
    }
}