using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    public int contador = 0;

    public virtual void UseItem(int index)
    {
        Debug.Log($"Using item: {Name} INDEX: {index}");

        if(Name == "PONTE")
        {
            ColocaPOnte.Instance.Coloca();
            contador++;
            if (contador == 2)
            {
                Destroy(gameObject);
            }
        }
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
