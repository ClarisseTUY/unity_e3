using System.Collections;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public float moveSpeed = 3f; // Vitesse de déplacement du lapin
    public Animator animator; // Référence à l'Animator du lapin
    public AnimationClip runAnimation; // Animation de course
    public AnimationClip idleAnimation; // Animation d'attente

    private bool isMoving = false; // Indique si le lapin est en mouvement

    void Start()
    {
        // Démarre la routine pour gérer les déplacements aléatoires
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
        // Si le lapin est en mouvement on déplace dans la direction donnée
        if (isMoving)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // regarde dans la direction du mouvement
            transform.LookAt(transform.position + transform.forward);
        }
    }

    // Routine pour gérer les déplacements aléatoires
    IEnumerator RandomMovement()
    {
        while (true)
        {
            
            bool isRunning = Random.value > 0.5f;

            
            if (isRunning)
            {
                animator.Play(runAnimation.name);
            }
            else
            {
                animator.Play(idleAnimation.name);
            }

            isMoving = true;

            yield return new WaitForSeconds(Random.Range(1f, 3f));

            isMoving = false;

            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
