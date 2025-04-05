using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;

    public virtual void UseItem()
    {
        // Implement item usage logic here
        Debug.Log($"Using item: {Name}");
    }

    public virtual void Pickup()
    {
        Sprite itemIcon = GetComponent<Image>().sprite;
        if (ItemPickupUIController.Instance != null)
        {
            ItemPickupUIController.Instance.ShowItemPickup(Name, itemIcon);
        }
    }
}
