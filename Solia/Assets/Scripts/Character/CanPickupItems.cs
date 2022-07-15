using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

//class for objects that can pickup items
public class CanPickupItems : MonoBehaviour
{
    [Tooltip("The range at which this object can pickup items")]
    [SerializeField] private float pickupRange;

    [Tooltip("The inventory in whick to stash the item")]
    [SerializeField] private Inventory inventory;

    //function that tries to pickup the closest item in range
    public void TryPickup(CallbackContext callback)
    {
        //check right state of press
        if(callback.performed)
        {
            //find the nearest pickable item
            PickableItem closest = Utils.FindNearestInRange<PickableItem>(transform, pickupRange);

            //check if it exists
            if(closest is null)
            {
                return;
            }

            //pickup the item
            closest.TryPickupItem(inventory);
        }
    }

    //debug sphere to show range
    private void OnDrawGizmosSelected()
    {
        //draw the range of the upgrader
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}