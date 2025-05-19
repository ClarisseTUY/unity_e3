using UnityEngine;
using UnityEngine.XR;

public class FoxSound : MonoBehaviour
{
    [SerializeField] public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
