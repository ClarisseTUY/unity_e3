using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RabbitInHand : MonoBehaviour
{
    [SerializeField] Animator rabbitInHand;
    [SerializeField] Transform attachPoint;
    [SerializeField] Transform deathAttachPoint;

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

}
