using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if(item.pego == true)
            {
                Debug.Log("Item já pego");
                return;
            }

            if (item.Name == "MOEDA")
            {
                item.pego = true;
                PlayerPrefs.SetFloat("moeda", PlayerPrefs.GetInt("moeda") + 1f);
                Debug.Log("MOEDA COLETADA");
                Destroy(collision.gameObject);
            }
            else
            {
                if (item != null)
                {
                    //bool itemAdded = inventoryController.AddItem(item.gameObject);
                    bool itemAdded = inventoryController.AddItemHotbar(item.gameObject);
                    if (itemAdded)
                    {
                        item.Pickup();
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
}
