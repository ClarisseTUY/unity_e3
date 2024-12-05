using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WolfInteraction : MonoBehaviour
{
    public bool playerInRange;

    public bool isStatic = true;
    public bool isChasing = false;
    public bool isReturningToPosition = false;
    public bool isAttacking = false; // Indique si le loup attaque le joueur

    public GameObject wolfAlert;
    public TMP_Text alertText;

    [SerializeField] private Transform player; // Le renard (joueur)
    [SerializeField] private float attackRange = 5f; // Distance pour attaquer
    [SerializeField] private float moveSpeed = 5f; // Vitesse du loup
    [SerializeField] private float returnSpeed = 3f; // Vitesse de retour à la position initiale

    private Vector3 initialPosition; // Position de départ du loup


    void Start()
    {
        // Sauvegarde la position initiale du loup
        initialPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Gestion de l'alerte visuelle
        if (playerInRange)
        {
            wolfAlert.SetActive(true);
            isStatic = false;
            isAttacking = false;
            isChasing = true;
            isReturningToPosition = false;
        }
        else
        {
            wolfAlert.SetActive(false);
            isAttacking = false;
            isChasing = false;
            isReturningToPosition = true;
        }


        if (distanceToPlayer <= attackRange)
        {
            // Si le joueur est assez proche, le loup attaque
            isAttacking = true;
            isChasing = false;
            isReturningToPosition = false;
            isStatic = false;
        }

        if (isAttacking)
        {
            isStatic = false;
            StopAndAttack();

        }
        else if (isChasing)
        {
            isStatic = false;
            ChasePlayer();
        }
        else if(isReturningToPosition)
        {
            ReturnToInitialPosition();
        }


    }

    private void ChasePlayer()
    {
        // Déplacement vers la position du joueur
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Orientation du loup vers le joueur
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    private void StopAndAttack()
    {
        // Arrête le loup et le maintient orienté vers le joueur
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        // Logique d'attaque (à compléter si nécessaire)
        Debug.Log("Le loup attaque le joueur !");
    }


    private void ReturnToInitialPosition()
    {
        // Déplacement vers la position initiale
        Vector3 direction = (initialPosition - transform.position).normalized;
        float distanceToInitial = Vector3.Distance(transform.position, initialPosition);

        if (distanceToInitial > 0.1f)
        {
            transform.position += direction * returnSpeed * Time.deltaTime;

            // Orientation du loup vers la position initiale
            transform.LookAt(new Vector3(initialPosition.x, transform.position.y, initialPosition.z));
        }
        else
        {
            // Lorsque le loup atteint sa position initiale
            isStatic = true; // Marquer le loup comme statique
            isReturningToPosition = false;
            Debug.Log("Le loup est revenu à sa position initiale.");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            isAttacking = false;
        }
    }

    public bool IsChasing()
    {
        return isChasing;
    }
    public bool IsReturningToPosition()
    {
        return isReturningToPosition;
    }
    public bool IsAttacking()
    {
        return isAttacking;
    }
    public bool IsStatic()
    { 
        return isStatic;
    }
}