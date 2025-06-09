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
        isWalking = Random.value > 0.5f;
        PickNewState();
        timer += Random.Range(0f, walkDuration + idleDuration);
    }

    void Update()
    {
        if (!animator.GetBool("Dead") && !animator.GetBool("inHand"))
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
    }

    void PickNewState()
    {
        timer = isWalking ? walkDuration : idleDuration;

        if (isWalking)
        {
            float angle = Random.Range(0f, 360f);
            direction = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)).normalized;
        }

        animator.SetBool("isWalking", isWalking);
    }
}
