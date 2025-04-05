using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateEscape(0);
    }

    public void ActivateEscape(int EscapeNo)
    {
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[EscapeNo].SetActive(true);
        tabImages[EscapeNo].color = Color.white;
    }

}