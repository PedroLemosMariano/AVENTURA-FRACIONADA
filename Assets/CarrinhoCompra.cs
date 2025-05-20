using UnityEngine;

public class CarrinhoCompra : MonoBehaviour
{
    public Sprite[] direcao; // 0: cima, 1: baixo, 2: esquerda, 3: direita
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 ultimaDirecao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Sprite inicial opcional
        if (direcao.Length > 0)
            spriteRenderer.sprite = direcao[1]; // começa com "baixo"
    }

    void Update()
    {
        Vector2 velocidade = rb.linearVelocity;

        if (velocidade.magnitude > 0.1f)
        {
            ultimaDirecao = velocidade.normalized;

            int direcaoIndex = -1;
            if (Mathf.Abs(ultimaDirecao.x) > Mathf.Abs(ultimaDirecao.y))
            {
                direcaoIndex = (ultimaDirecao.x > 0) ? 3 : 2; // direita ou esquerda
            }
            else
            {
                direcaoIndex = (ultimaDirecao.y > 0) ? 0 : 1; // cima ou baixo
            }

            // Atualiza o sprite mostrado
            if (direcaoIndex >= 0 && direcaoIndex < direcao.Length)
            {
                spriteRenderer.sprite = direcao[direcaoIndex];

                // Define a sorting layer com base na direção
                spriteRenderer.sortingLayerName = (direcaoIndex == 1) ? "ADEREÇOS" : "PISO";
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // lógica opcional ao colidir com o jogador
        }
    }
}

