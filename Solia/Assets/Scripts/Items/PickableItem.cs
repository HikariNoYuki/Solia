using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [Tooltip("The items list to use")]
    [SerializeField] private ItemsList itemsList;

    [Tooltip("The category of the item")]
    [SerializeField] private ItemCategory.CategoryList category;

    [Tooltip("The id of the item (element number in ItemListData)")]
    [SerializeField] private int id;

    [Tooltip("The sprite renderer to use for showing the item")]
    [SerializeField] private SpriteRenderer sprite;

    //the item associated with this object
    private Item myItem;

    // Start is called before the first frame update
    private void Start() => LoadItem();

    // Update is called once per frame
    private void Update()
    {
    }

    //called when an value in the editor is changed
    private void OnValidate() => LoadItem();

    //load the item into the gameobject (especially the sprite)
    private void LoadItem()
    {
        //search the item is the itemsList
        myItem = itemsList.items.GetItem(id, category);

        //change the sprite of the object
        sprite.sprite = myItem.itemSprite;
    }
}