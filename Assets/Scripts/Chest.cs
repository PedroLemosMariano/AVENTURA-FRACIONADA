using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; }
    public string ChestID { get; private set; }
    public GameObject itemPrefab;
    public Sprite openedSprite;
    public int index;

    private void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject);

        // Verifica se já foi aberto
        if (PlayerPrefs.GetInt("Chest_" + index, 0) == 1)
        {
            SetOpened(true);
        }
    }

    public bool CanInteract()
    {
        return !IsOpened;
    }

    public void Interact()
    {
        if (!CanInteract()) return;
        OpenChest();
    }

    private void OpenChest()
    {
        SetOpened(true);
        SoundEffectManager.Play("Chest");

        if (itemPrefab)
        {
            GameObject droppedItem = Instantiate(itemPrefab, transform.position + Vector3.down, Quaternion.identity);
            droppedItem.GetComponent<BounceEffect>().StartBounce();
        }

        // Salva o estado como "aberto"
        PlayerPrefs.SetInt("Chest_" + index, 1);
        PlayerPrefs.Save();
    }

    public void SetOpened(bool opened)
    {
        if (IsOpened = opened)
        {
            GetComponent<SpriteRenderer>().sprite = openedSprite;
        }
    }
}
