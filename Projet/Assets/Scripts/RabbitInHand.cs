using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RabbitInHand : MonoBehaviour
{
    [SerializeField] Animator rabbitInHand;
    [SerializeField] Transform attachPoint;
    [SerializeField] Transform deathAttachPoint;
    [SerializeField] private string mouthTag = "Mouth";
    private bool isEaten = false;
    [SerializeField] private ParticleSystem bloodEffect;


    private XRGrabInteractable grabbable;
    private bool isDead = false;

    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.attachTransform = attachPoint;
        grabbable.activated.AddListener(RabbitDeath);
        grabbable.selectEntered.AddListener(OnGrabbed);
        grabbable.selectExited.AddListener(OnReleased);

    }

    public void RabbitDeath(ActivateEventArgs arg)
    {
        if (isDead) return;
        isDead = true;

        rabbitInHand.SetBool("Dead", true);

        if (grabbable.isSelected)
        {
            IXRSelectInteractor interactor = grabbable.firstInteractorSelecting;
            XRInteractionManager interactionManager = grabbable.interactionManager;

            interactionManager.SelectExit(interactor, grabbable);

            grabbable.attachTransform = deathAttachPoint;

            interactionManager.SelectEnter(interactor, grabbable);
        }
        else
        {
            grabbable.attachTransform = deathAttachPoint;
        }
    }
    private void OnGrabbed(SelectEnterEventArgs arg)
    {
        rabbitInHand.SetBool("inHand", true);
    }

    private void OnReleased(SelectExitEventArgs arg)
    {
        rabbitInHand.SetBool("inHand", false);
        rabbitInHand.SetBool("isWalking", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isEaten) return;

        if (other.CompareTag(mouthTag) && rabbitInHand.GetBool("Dead"))
        {
            StartCoroutine(EatRabbit());
        }
    }

    public IEnumerator EatRabbit()
    {
        if (isEaten) yield break;
        isEaten = true;

        //rabbitInHand.SetTrigger("Eaten");

        for (int i = 0; i < 3; i++)
        {
            if (bloodEffect != null)
            {
                bloodEffect.gameObject.SetActive(true);
                bloodEffect.Play();
            }

            yield return new WaitForSeconds(0.5f); 

            if (bloodEffect != null)
            {
                bloodEffect.gameObject.SetActive(false);
                bloodEffect.Stop();
                bloodEffect.Clear();
            }

            yield return new WaitForSeconds(0.2f); 
        }

        gameObject.SetActive(false);
        Destroy(gameObject);
        rabbitInHand.SetBool("inHand", false);

        Debug.Log("Lapin mangé à la bouche !");

    }

}
