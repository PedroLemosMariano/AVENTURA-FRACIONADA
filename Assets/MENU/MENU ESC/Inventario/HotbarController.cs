using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Collections;

public class HotbarController : MonoBehaviour
{
    public GameObject hotbarPanel;
    public GameObject slotPrefab;
    public int slotCount = 10;

    private ItemDictionary itemDictionary;
    private Key[] hotbarKeys;

    [SerializeField] private bool carregarUltimaPosicao;
    [SerializeField] private bool masNaoNesseCaso;
  

    private void Awake()
    {
        itemDictionary = FindFirstObjectByType<ItemDictionary>();

        hotbarKeys = new Key[slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            hotbarKeys[i] = i < 9 ? (Key)((int)Key.Digit1 + i) : Key.Digit0;
        }

        if (carregarUltimaPosicao && !masNaoNesseCaso)
        {
            FindAnyObjectByType<PlayerMovement>().transform.position = new Vector2(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"));

        }
    }

    void Update()
    {
        for (int i = 0; i < slotCount; i++)
        {
            if (Keyboard.current[hotbarKeys[i]].wasPressedThisFrame)
            {
                UseItemInSlot(i);
            }
        }
    }

    void UseItemInSlot(int index)
    {
        Slot slot = hotbarPanel.transform.GetChild(index).GetComponent<Slot>();
        if (slot.currentItem != null)
        {
            Item item = slot.currentItem.GetComponent<Item>();
            item.UseItem(index);
        }
    }

    public List<InventorySaveData> GetHotbarItems()
    {
        List<InventorySaveData> hotbarData = new List<InventorySaveData>();
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                hotbarData.Add(new InventorySaveData{itemID = item.ID,slotIndex = slotTransform.GetSiblingIndex()});

            }
        }
        return hotbarData;
    }

    public void SetHotbarItems(List<InventorySaveData> hotbarSaveData)
    {
        // Limpa apenas os itens dentro dos slots, mantendo os slots
        foreach (Transform slotTransform in hotbarPanel.transform)
        {
            if (slotTransform.childCount > 0)
            {
                Destroy(slotTransform.GetChild(0).gameObject);
            }
        }

        for (int i = 0; i <slotCount; i++)
        {
            Instantiate(slotPrefab, hotbarPanel.transform);
        }

        foreach (InventorySaveData data in hotbarSaveData)
        {
            if (data.slotIndex < slotCount)
            {
                Slot slot = hotbarPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if (itemPrefab != null)
                {
                        GameObject item = Instantiate(itemPrefab, slot.transform);
                        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                        slot.currentItem = item;
                }
            }
        }
    }
}
