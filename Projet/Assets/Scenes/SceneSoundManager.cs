using UnityEngine;

public class SceneSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        // Assurez-vous que l'AudioSource est configuré
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // Jouer la musique de fond de la scène
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        // Charger et jouer la musique de fond de la scène
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
