using UnityEngine;
using System.Collections;

public class moveoffset : MonoBehaviour
{
    private Material materialAtual;
    public float velocidade;
    public float offsetX ;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materialAtual = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offsetX += 0.01f;
        materialAtual.SetTextureOffset("_MainTex", new Vector2(offsetX * velocidade, 0));
    }
}
