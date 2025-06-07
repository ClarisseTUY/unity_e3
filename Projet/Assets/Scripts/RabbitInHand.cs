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

        // Si une main tient le lapin
        if (grabbable.isSelected)
        {
            // Obtenir l'interactor qui tient l'objet (main ou socket)
            IXRSelectInteractor interactor = grabbable.firstInteractorSelecting;
            XRInteractionManager interactionManager = grabbable.interactionManager;

            // 1. Forcer le release
            interactionManager.SelectExit(interactor, grabbable);

            // 2. Changer le point d'attache
            grabbable.attachTransform = deathAttachPoint;

            // 3. Forcer la main à reprendre
            interactionManager.SelectEnter(interactor, grabbable);
        }
        else
        {
            // Si pas tenu, juste changer l’attach point
            grabbable.attachTransform = deathAttachPoint;
        }
    }
}
