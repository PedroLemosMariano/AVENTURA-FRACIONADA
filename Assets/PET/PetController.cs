using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PetController : MonoBehaviour
{
    public GameObject Player;
    public Animator petAnimator;

    public float speed = 1;
    public float keepDistance = 0.3f;

    bool IsWalking;

    float InputX;
    float InputY;
    float LastDirectionX;
    float LastDirectionY;

    Vector2 petPos;
    Vector2 playerPos;

    private void Start()
    {
        petAnimator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");

        petPos = transform.position;
        playerPos = SetDirection(1, 1, Player.transform.position);

        transform.position = Vector2.MoveTowards(petPos, playerPos, speed * Time.deltaTime);
    }

    private void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        IsWalking = (InputX != 0 || InputY != 0);

        if (IsWalking)
        {
            petAnimator.SetFloat("InputX", InputX);
            petAnimator.SetFloat("InputY", InputY);
        }

        if (InputX > 0 || InputX < 0) LastDirectionX = InputX;
        if (InputY > 0 || InputY < 0) LastDirectionY = InputY;

        petAnimator.SetBool("IsWalking", IsWalking);

        if (InputX != 0)
        {
            GetComponent<SpriteRenderer>().flipX = InputX > 0;

        }

        petPos = transform.position;
        playerPos = SetDirection(LastDirectionX, LastDirectionY, Player.transform.position);

        transform.position = Vector2.MoveTowards(petPos, playerPos, speed * Time.deltaTime);
    }

    Vector2 SetDirection(float InputX, float InputY, Vector2 playerPos)
    {
        if(InputX < 0)
        {
            playerPos.x += keepDistance;
        }
        else if (InputX > 0)
        {
            playerPos.x -= keepDistance;
        }

        if (InputY < 0)
        {
            playerPos.y += keepDistance;
        }
        else if (InputY > 0)
        {
            playerPos.y -= keepDistance;
        }

        return playerPos;
    }
}
