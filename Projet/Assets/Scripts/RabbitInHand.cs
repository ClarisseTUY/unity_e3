using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RabbitInHand : MonoBehaviour
{
    [SerializeField] Animator rabbitInHand;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(RabbitDeath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RabbitDeath(ActivateEventArgs arg)
    {
        rabbitInHand.SetTrigger("Death");
    }
}
