using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    public float floatSpeed = 0.5f; // Vitesse de flottement (ajustez selon vos besoins)
    public float floatHeight = 0.5f; // Hauteur de flottement (ajustez selon vos besoins)
    private Vector3 startPos; // Position de départ

    private void Start()
    {
        // Enregistrer la position de départ de l'objet
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculer le déplacement vertical basé sur le temps
        float offset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Définir la nouvelle position de l'objet en ajoutant l'offset vertical
        transform.position = startPos + new Vector3(0f, offset, 0f);
    }
}
