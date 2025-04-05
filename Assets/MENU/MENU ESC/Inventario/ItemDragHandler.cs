using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private CanvasGroup canvasGroup;

    public float minDropDistance = 2f;
    public float maxDropDistance = 3f;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>(); // Garante que CanvasGroup existe
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        Slot dropSlot = eventData.pointerEnter?.GetComponentInParent<Slot>();
        Slot originalSlot = originalParent?.GetComponent<Slot>();

        if (dropSlot != null && originalSlot != null)
        {
            if (dropSlot.currentItem != null)
            {
                // Troca os itens entre os slots
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                originalSlot.currentItem = null;
            }

            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            if (!IsWithinInventory(eventData.position))
            {
                DropItem(originalSlot);
            }
            else
            {
                transform.SetParent(originalParent);
            }
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    bool IsWithinInventory(Vector2 mousePosition)
    {
        if (originalParent?.parent == null) return false;

        RectTransform inventoryRect = originalParent.parent.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(inventoryRect, mousePosition);
    }

    void DropItem(Slot originalSlot)
    {
        originalSlot.currentItem = null;

        Transform playerTransform = GameObject.FindWithTag("Player")?.transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player não encontrado!");
            return;
        }

        Vector2 dropOffset = Random.insideUnitCircle.normalized * Random.Range(minDropDistance, maxDropDistance);
        Vector2 dropPosition = (Vector2)playerTransform.position + dropOffset;

        GameObject dropItem = Instantiate(gameObject, dropPosition, Quaternion.identity);
        dropItem.GetComponent<BounceEffect>().StartBounce();

        Destroy(gameObject);
    }
}
