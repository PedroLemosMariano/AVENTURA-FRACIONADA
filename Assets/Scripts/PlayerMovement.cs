using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private bool playingFootsteps = false;
    public float footstepSpeed = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void AtivarAgilidade()
    {
        moveSpeed += 2f;
        Debug.Log("Agilidade ativada ao vivo! Velocidade atual: " + moveSpeed);
    }


    void Update()
    {
        if (PauseController.IsGamePaused)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            StopFootsteps();
            return;
        }

        rb.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", rb.linearVelocity.sqrMagnitude > 0);

        if (moveInput.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveInput.x < 0;
        }

        if (rb.linearVelocity.magnitude > 0 && !playingFootsteps)
        {
            StartFootsteps();
        }
        else if (rb.linearVelocity.magnitude == 0)
        {
            StopFootsteps();
        }
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }


    private void StartFootsteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootstep), 0f, Mathf.Max(0.1f, footstepSpeed));

    }

    private void StopFootsteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootstep));

    }

    private void PlayFootstep()
    {
        Debug.Log("Play Footstep");
        SoundEffectManager.Play("Footstep", true);
    }

}
