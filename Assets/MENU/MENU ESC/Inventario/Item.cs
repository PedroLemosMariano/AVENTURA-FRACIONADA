using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    public int contador = 0;
    public bool pego = false;
    public int valor = 1;

    public virtual void UseItem(int index)
    {
        Debug.Log($"Using item: {Name} INDEX: {index}");

        if(Name == "PONTE")
        {
            ColocaPOnte.Instance.ColocaTudo();
            contador++;
            if (contador == 1)
            {
                Destroy(gameObject);
            }
        }
        if(Name == "ESCADARIA")
        {
            ColocaPOnte.Instance.ColocaEscada();
            contador++;
            if (contador == 1)
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
            pego = true;
            ItemPickupUIController.Instance.ShowItemPickup(Name, itemIcon);
        }
    }
}
