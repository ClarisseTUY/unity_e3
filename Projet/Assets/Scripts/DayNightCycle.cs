using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight;   // Lumière du soleil
    public Light moonLight;  // Lumière de la lune
    public float dayDuration = 120f; // Durée totale jour+nuit en secondes (2 minutes)
    private float timeOfDay = 0f;

    void Update()
    {
        // Calcul du cycle en fonction du temps écoulé
        timeOfDay += (Time.deltaTime / dayDuration) * 360f; // 360° pour un cycle complet

        // Gérer la rotation du Soleil et de la Lune
        float sunRotation = timeOfDay - 90f;
        float moonRotation = timeOfDay + 90f;

        sunLight.transform.rotation = Quaternion.Euler(new Vector3(sunRotation, 170f, 0f));
        moonLight.transform.rotation = Quaternion.Euler(new Vector3(moonRotation, 170f, 0f));

        // Ajuster l'intensité du soleil et de la lune pour qu'on voie bien le jour et la nuit
        float normalizedTime = Mathf.Sin(timeOfDay * Mathf.Deg2Rad); // Oscillation entre -1 et 1

        // Lumière du jour (Soleil)
        sunLight.intensity = Mathf.Lerp(3f, 6f, Mathf.Clamp01(normalizedTime)); // Soleil : intensité plus élevée pour un jour lumineux

        // Lumière de la nuit (Lune)
        moonLight.intensity = Mathf.Lerp(1f, 3f, Mathf.Clamp01(-normalizedTime)); // Lune : intensité plus douce mais visible la nuit

        // Activer/désactiver les lumières selon leur intensité
        sunLight.enabled = sunLight.intensity > 0.01f;
        moonLight.enabled = moonLight.intensity > 0.01f;

        // Remettre à zéro pour éviter que le compteur ne devienne trop grand
        if (timeOfDay >= 360f)
        {
            timeOfDay = 0f;
        }
    }
}
