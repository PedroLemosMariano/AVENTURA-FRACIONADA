using UnityEngine;

public class MoverSimbolo : MonoBehaviour
{
    public float velocity = 1f; // Speed of the symbol movement
    private Vector3 posicaoInicial;
    public float alturaMaxima = 1.5f; // Maximum height the symbol can reach
    public bool sobeEdesceAteOChao; // If true, the symbol will move up and down until it reaches the ground

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       posicaoInicial = transform.position; // Store the initial position of the symbol 
    }

    // Update is called once per frame
    void Update()
    {
        if (sobeEdesceAteOChao)
        {
            transform.position -= Vector3.up * velocity * Time.deltaTime;
            transform.localScale /= 1.0018f;
            if (transform.position.y <= posicaoInicial.y)
            {
                sobeEdesceAteOChao = false;
            }
        }
        else
        {
            transform.position += Vector3.up * velocity * Time.deltaTime;
            transform.localScale *= 1.0018f;
            if (transform.position.y >= posicaoInicial.y + alturaMaxima)
            {
                sobeEdesceAteOChao = true;
            }
        }
    }
}
