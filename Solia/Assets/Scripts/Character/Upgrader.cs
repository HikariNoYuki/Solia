using UnityEngine;
using UnityEngine.InputSystem;

//class that defines an entity allowed to upgrade buildings
public class Upgrader : MonoBehaviour
{
    [Tooltip("The range of the upgrader")]
    [SerializeField] private int upgradeRange;

    [Tooltip("The inventory to use when trying to upgrade")]
    [SerializeField] private Inventory upgradeInventory;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //debug sphere to show range
    private void OnDrawGizmosSelected()
    {
        //draw the range of the upgrader
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, upgradeRange);
    }

    public void TryUpgradeClosest(InputAction.CallbackContext context)
    {
        //check if key is pressed (otherwise, trigger 3 times : pressed, hold, let go)
        if(context.performed)
        {
            Debug.Log("Tried upgrading closest");

            //search if there is an upgradable in the range
            UpgradableModule closest = Utils.FindNearestInRange<UpgradableModule>(transform, upgradeRange);

            //closest still null means no upgradable in range
            if(closest == null)
            {
                return;
            }

            //call the upgrade function on the upgradable with my inventory and try to upgrade
            closest.TryUpgrade(upgradeInventory);
        }
    }
}