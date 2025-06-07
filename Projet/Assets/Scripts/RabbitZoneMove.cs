using UnityEngine;

public class RabbitZoneMove : MonoBehaviour
{
    public float walkDuration = 3f;
    public float idleDuration = 2f;
    public float speed = 1.5f;

    private Animator animator;
    private Vector3 direction;
    private float timer;
    private bool isWalking;

    void Start()
    {
        animator = GetComponent<Animator>();
        PickNewState();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            isWalking = !isWalking;
            PickNewState();
        }

        if (isWalking)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            transform.forward = direction;
        }
    }

    void PickNewState()
    {
        timer = isWalking ? walkDuration : idleDuration;

        if (isWalking)
        {
            direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }

        if (animator != null)
            animator.SetBool("isWalking", isWalking);
    }
}
