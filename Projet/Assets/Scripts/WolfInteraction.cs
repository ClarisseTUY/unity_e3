using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WolfInteraction : MonoBehaviour
{
    public bool playerInRange;
    public GameObject wolfAlert;
    public TMP_Text alertText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(playerInRange)
        {
            wolfAlert.SetActive(true);
        }
        if(!playerInRange)
        {
            wolfAlert.SetActive(false);
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
        }
    }
}
