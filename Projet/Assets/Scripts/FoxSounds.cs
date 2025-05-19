using UnityEngine;
using UnityEngine.XR;

public class FoxSounds : MonoBehaviour
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
            Debug.Log("test");
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
