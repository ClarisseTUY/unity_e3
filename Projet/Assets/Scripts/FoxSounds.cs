using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FoxSounds : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip;
    private AudioSource audioSource;

    public InputActionProperty secondaryButton;

    private bool isPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    void Update()
    {


        if (secondaryButton.action.IsPressed() && !isPlaying)
        {
            audioSource.Play();
            isPlaying = true;
        }

        if (isPlaying && !audioSource.isPlaying)
        {
            isPlaying = false;
        }
    }
}
