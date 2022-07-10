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
            UpgradableModule[] upgradables = FindObjectsOfType<UpgradableModule>();

            UpgradableModule closest = null;
            float minDistance = Mathf.Infinity;
            foreach(UpgradableModule upgradableModule in upgradables)
            {
                float curDistance = Vector2.Distance(upgradableModule.transform.position, transform.position);
                //check if in range
                if(!( curDistance <= upgradeRange ))
                {
                    continue;
                }

                //check if first in range
                //check if closer than closest
                if(closest == null || minDistance > curDistance)
                {
                    closest = upgradableModule;
                    minDistance = curDistance;
                }
            }
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