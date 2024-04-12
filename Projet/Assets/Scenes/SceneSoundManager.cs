using UnityEngine;

public class SceneSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundMusic;

    void Start()
    {
        // Assurez-vous que l'AudioSource est configur�
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }

        // Jouer la musique de fond de la sc�ne
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        // Charger et jouer la musique de fond de la sc�ne
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }
}
