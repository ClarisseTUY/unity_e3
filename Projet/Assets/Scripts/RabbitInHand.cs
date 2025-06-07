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
    }

    public void RabbitDeath(ActivateEventArgs arg)
    {
        if (isDead) return;
        isDead = true;

        rabbitInHand.SetTrigger("Death");

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
}
